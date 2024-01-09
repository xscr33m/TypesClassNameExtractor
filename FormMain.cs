using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using TypesClassNameExtractor.Core._Forms;
using xscr33mLabs_TypesClassNameExtractor.Core._Engine;

namespace TypesClassNameExtractor
{
    public partial class FormMain : Form
    {
        private readonly Timer rotationTimer = new Timer();
        private const int rotationStep = 2;
        private int currentRotation = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await UpdateCheck.CheckForUpdates();
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            // Überprüfe, ob die abgelegte Daten eine Datei ist
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Erlaube das Kopieren der Daten
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            // Hole die abgelegten Dateien
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Überprüfe, ob mindestens eine Datei vorhanden ist
            if (files.Length > 0)
            {
                // Nehme die erste Datei und führe die Extraktion durch
                string filePath = files[0];
                RunConversion(filePath);
            }
        }

        private void ButtonLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Types.xml (*.xml)|*.xml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RunConversion(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    UpdateStatusLabel($"[ERROR] <Error: {ex.Message}>");
                }
            }
        }

        private async void RunConversion(string filePath)
        {
            IconPictureBoxLoading.Visible = true;
            rotationTimer.Interval = 1;
            rotationTimer.Tick += RotationTimer_Tick;
            rotationTimer.Start();

            UpdateStatusLabel("Converting... Please Wait...");

            try
            {
                await Task.Run(() => ExtractTypeNames(filePath));
            }
            catch (Exception ex)
            {
                UpdateStatusLabel($"[ERROR] <Error: {ex.Message}>");
            }
            finally
            {
                await Task.Delay(1000);
                rotationTimer.Stop();
                IconPictureBoxLoading.Visible = false;
                await Task.Delay(10000);
                UpdateStatusLabel("Drop or Load Types.xml");
            }
        }

        private async void ExtractTypeNames(string filePath)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                // Extrahiere die Type-Namen
                var typeNames = doc.Descendants("type")
                                   .Select(type => type.Attribute("name").Value)
                                   .ToList();

                // Speichere die Type-Namen in eine Datei
                string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "ClassNames.txt");

                if (File.Exists(outputFilePath))
                {
                    CustomMessage messageBox = new CustomMessage();
                    SystemSounds.Exclamation.Play();
                    messageBox.ButtonOkay.Visible = false;
                    messageBox.IconPictureBox.IconChar = IconChar.Warning;
                    messageBox.IconPictureBox.ForeColor = Color.Yellow;
                    messageBox.LabelMessageContent.Text = "ClassNames.txt file already exists. Would you like to overwrite it?";
                    messageBox.Text = "Question";
                    messageBox.ButtonNo.Text = "No";
                    messageBox.ButtonYes.Text = "Yes";
                    messageBox.ButtonNo.Visible = true;
                    messageBox.ButtonYes.Visible = true;

                    if (messageBox.ShowDialog() == DialogResult.No)
                    {
                        UpdateStatusLabel("Extraction canceled!");
                        await Task.Delay(5000);
                        UpdateStatusLabel("Load or Drop Types.xml");
                        return;
                    }
                }

                File.WriteAllLines(outputFilePath, typeNames);

                await Task.Delay(1000);

                // Zeige die Summe der exportierten Type-Namen an
                UpdateStatusLabel($"Total Types Exported: {typeNames.Count}");
            }
            catch (XmlException ex)
            {
                string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "ClassNameExtractor_ErrorLog.txt");

                CustomMessage messageBox = new CustomMessage();
                SystemSounds.Exclamation.Play();
                messageBox.ButtonOkay.Text = "Okay";
                messageBox.ButtonOkay.Visible = true;
                messageBox.IconPictureBox.IconChar = IconChar.Xmark;
                messageBox.IconPictureBox.ForeColor = Color.Red;
                messageBox.LabelMessageContent.Text = $"XML-Parsing failed:\n\n{ex.Message}\n";
                messageBox.Text = "Fehler";
                messageBox.ButtonNo.Text = "No";
                messageBox.ButtonYes.Text = "Yes";
                messageBox.ButtonNo.Visible = false;
                messageBox.ButtonYes.Visible = false;

                if (messageBox.ShowDialog() == DialogResult.OK)
                {
                    File.AppendAllText(outputFilePath, $"{DateTime.Now}: XML-Parsing failed: {ex.Message}\n");
                    UpdateStatusLabel($"XML-Parsing failed! Check the Error-Message and try again!");
                }
            }
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            // Setze den Rotationswert nach jeder vollen Umdrehung zurück
            currentRotation += rotationStep;
            if (currentRotation >= 360)
            {
                currentRotation -= 360;
            }

            IconPictureBoxLoading.Rotation += 2;

            // Aktualisiere das Icon
            IconPictureBoxLoading.IconChar = IconChar.Hourglass;
            IconPictureBoxLoading.IconSize = 40;
            IconPictureBoxLoading.IconColor = GetGradientColor();

            // Zeichne das Icon neu
            IconPictureBoxLoading.Invalidate();
        }

        private Color GetGradientColor()
        {
            // Berechne die Farbe basierend auf der aktuellen Rotation
            int red = (int)(Math.Sin(Math.PI * currentRotation / 180) * 127 + 128);
            int green = (int)(Math.Sin(Math.PI * (currentRotation + 120) / 180) * 127 + 128);
            int blue = (int)(Math.Sin(Math.PI * (currentRotation + 240) / 180) * 127 + 128);

            return Color.FromArgb(red, green, blue);
        }

        public void UpdateStatusLabel(string text)
        {
            if (LabelStatus.InvokeRequired)
            {
                LabelStatus.Invoke(new Action<string>(UpdateStatusLabel), text);
            }
            else
            {
                LabelStatus.Text = text;
            }
        }

        // --- Black TitleBar --- //
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
    }
}
