using FontAwesome.Sharp;
using Octokit;
using System;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypesClassNameExtractor.Core._Forms;

namespace xscr33mLabs_TypesClassNameExtractor.Core._Engine
{
    public class UpdateCheck
    {
        public static async Task CheckForUpdates()
        {
            try
            {
                // Erzeuge eine GitHubClient-Instanz
                var github = new GitHubClient(new ProductHeaderValue("TypesClassNameExtractor"));

                // Setze den Benutzer und das Repository deines öffentlichen GitHub-Repos
                string owner = "xscr33m";
                string repo = "TypesClassNameExtractor";

                // Rufe die Liste der neuesten Releases ab
                var releases = await github.Repository.Release.GetAll(owner, repo);

                // Sortiere die Releases absteigend nach dem Veröffentlichungsdatum
                var sortedReleases = releases.OrderByDescending(r => r.PublishedAt);

                // Vergleiche die AssemblyVersion mit dem neuesten Tag
                Version currentVersion = Assembly.GetEntryAssembly().GetName().Version;
                Version latestVersion = new Version(sortedReleases.FirstOrDefault()?.TagName.TrimStart('v'));

                if (latestVersion != null && latestVersion > currentVersion)
                {
                    // Eine neuere Version wurde gefunden, zeige eine entsprechende Benachrichtigung an
                    CustomMessage popUpMessage = new CustomMessage();
                    SystemSounds.Exclamation.Play();
                    popUpMessage.ButtonOkay.Visible = false;
                    popUpMessage.IconPictureBox.IconChar = IconChar.Warning;
                    popUpMessage.LabelMessageContent.Text = "A newer version is available! \n\r \n\rDo you want to download it now?";
                    popUpMessage.Text = "Update available!";
                    popUpMessage.ButtonNo.Visible = true;
                    popUpMessage.ButtonYes.Visible = true;
                    DialogResult updateDialog = popUpMessage.ShowDialog();

                    if (updateDialog == DialogResult.Yes)
                    {
                        string downloadUrl = string.Format("https://github.com/{0}/{1}/releases/download/{2}/xscr33mLabs_TypesClassNameExtractor.zip", owner, repo, sortedReleases.FirstOrDefault()?.TagName);
                        string changelogUrl = string.Format("https://github.com/{0}/{1}/releases/", owner, repo);

                        try
                        {
                            Process.Start(downloadUrl);
                            Process.Start(changelogUrl);
                        }
                        catch
                        {
                            CustomMessage popUpErrorMessage = new CustomMessage();
                            SystemSounds.Exclamation.Play();
                            popUpErrorMessage.ButtonOkay.Visible = true;
                            popUpErrorMessage.IconPictureBox.IconChar = IconChar.Warning;
                            popUpErrorMessage.LabelMessageContent.Text = "Browser could not be started.";
                            popUpErrorMessage.Text = "Error!";
                            popUpErrorMessage.ButtonNo.Visible = false;
                            popUpErrorMessage.ButtonYes.Visible = false;
                            popUpErrorMessage.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Behandle Fehler bei der Verbindung zur GitHub-API
                CustomMessage popUpErrorMessage = new CustomMessage();
                SystemSounds.Exclamation.Play();
                popUpErrorMessage.ButtonOkay.Visible = true;
                popUpErrorMessage.IconPictureBox.IconChar = IconChar.Warning;
                popUpErrorMessage.LabelMessageContent.Text = "Error while checking for updates: " + ex.Message;
                popUpErrorMessage.Text = "Error!";
                popUpErrorMessage.ButtonNo.Visible = false;
                popUpErrorMessage.ButtonYes.Visible = false;
                popUpErrorMessage.ShowDialog();
            }
        }
    }
}
