using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wissensmanagement
{
    [Serializable]
    public class Tag
    {
        // Attributes
        public string tag_Name;

        // Constructor
        public Tag(string tag_Name)
        {
            this.tag_Name = tag_Name;
        }
    }

    [Serializable]
    public class Info
    {
        // Attributes
        public string title;
        public string text;
        public string date;
        public List<Tag> tags;
        public List<string> comments = new List<string>();

        // Constructor
        public Info(string title, string text, string date, List<Tag> tags)
        {
            this.title = title;
            this.text = text;
            this.date = date;
            this.tags = tags ?? new List<Tag>();
            this.comments = new List<string>();
        }

        // Method
        public void addTag(Tag tag)
        {
            tags.Add(tag);
        }

        public void removeTag(Tag tag)
        {
            tags.Remove(tag);
        }

        public void addComment(string comment)
        {
            if (comments == null)
            {
                comments = new List<string>();  // Sicherstellen, dass die Liste existiert
            }
            comments.Add(comment);
        }

        public string getText()
        {
            return text;
        }

        public string getTitle()
        {
            return title;
        }
    }

    [Serializable]
    public class Project
    {
        // Attributes
        public string project_Name;
        public List<Info> project_Info = new List<Info>();
        public List<Tag> project_Tags = new List<Tag>();

        // Constructor
        public Project(string project_Name)
        {
            this.project_Name = project_Name;
        }

        // Method
        public string getProjectName()
        {
            return project_Name;
        }

        public List<Info> getProjectInfo()
        {
            return project_Info;
        }

        public List<Tag> getProjectTags()
        {
            return project_Tags;
        }

        public void addInfo(Info info)
        {
            project_Info.Add(info);
        }

        public void removeInfo(Info info)
        {
            project_Info.Remove(info);
        }

        public void addTag(Tag tag)
        {
            project_Tags.Add(tag);
        }

        public void removeTag(Tag tag)
        {
            project_Tags.Remove(tag);
        }
    }

    public class WissensmanagementApp
    {
        private List<Project> projects = new List<Project>();
        private const string SpeicherDatei = "C:\\Temp\\projects.dat";

        public void NeuesProjektErstellen(string projektName)
        {
            var projekt = new Project(projektName);
            projects.Add(projekt);
            Speichern();
            MessageBox.Show("Projekt erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<Project> GetProjects()
        {
            return projects;
        }

        public void NeueInformationHinzufuegen(string projektName, string title, string text, string date, List<Tag> tags)
        {
            var projekt = projects.FirstOrDefault(p => p.project_Name == projektName);
            if (projekt == null)
            {
                MessageBox.Show("Projekt nicht gefunden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var info = new Info(title, text, date, tags);
            projekt.addInfo(info);
            Speichern();
            MessageBox.Show("Information erfolgreich hinzugefügt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void InformationenSuchen()
        {
            Console.Write("Tag eingeben: ");
            string tag = Console.ReadLine();

            var ergebnisse = projects
                .SelectMany(p => p.getProjectInfo(), (projekt, info) => new { projektName = projekt.getProjectName(), Info = info })
                .Where(p => p.Info.tags.Any(t => t.tag_Name.Equals(tag, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (ergebnisse.Any())
            {
                foreach (var ergebnis in ergebnisse)
                {
                    Console.WriteLine($"Projekt: {ergebnis.projektName}, Titel: {ergebnis.Info.getTitle()}, Inhalt: {ergebnis.Info.getText()}");
                }
            }
            else
            {
                Console.WriteLine("Keine Informationen gefunden.");
            }
        }

        public void Speichern()
        {
            using (var stream = new FileStream(SpeicherDatei, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, projects);
            }
        }

        public void Laden()
        {
            if (File.Exists(SpeicherDatei))
            {
                using (var stream = new FileStream(SpeicherDatei, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    projects = (List<Project>)formatter.Deserialize(stream);
                }
            }
        }

        public static void Main(string[] args)
        {
            var app = new WissensmanagementApp();
            app.Laden();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1(app));
        }
    }

    public partial class Form1 : Form
    {
        private WissensmanagementApp app;

        public Form1(WissensmanagementApp app)
        {
            InitializeComponent();
            this.app = app;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
        }

        private void create_project_Click(object sender, EventArgs e)
        {
            string projektname = projektname_tb.Text;

            if (string.IsNullOrWhiteSpace(projektname))
            {
                MessageBox.Show("Projektname darf nicht leer sein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Erstelle neues Projekt
            app.NeuesProjektErstellen(projektname);

            // Felder leeren
            projektname_tb.Clear();
            kunde_tb.Clear();
            projektleiter_tb.Clear();
            kernanforderung_tb.Clear();

            UpdateComboBox();
        }

        private void information_hinzufuegen_btn_Click(object sender, EventArgs e)
        {
            if (project_cb.SelectedItem == null)
            {
                MessageBox.Show("Bitte ein Projekt auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string projektname = project_cb.SelectedItem.ToString();
            string title = information_text_tb.Text.Length > 10 ? information_text_tb.Text.Substring(0, 10) : information_text_tb.Text;
            string text = $"Text: {information_text_tb.Text}\nBild: {information_bilder_tb.Text}\nDokument: {information_dokumente_tb.Text}";
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Tag> tags = informationen_tags_tb.Text.Split(',').Select(t => new Tag(t.Trim())).ToList();

            app.NeueInformationHinzufuegen(projektname, title, text, date, tags);

            // Felder leeren
            information_text_tb.Clear();
            information_bilder_tb.Clear();
            information_dokumente_tb.Clear();
            informationen_tags_tb.Clear();

        }

        private void suchen_btn_Click(object sender, EventArgs e)
        {
            // Lade die gespeicherten Projekte aus der Datei
            app.Laden();

            // Überprüfe, ob ein Projekt ausgewählt wurde
            if (suche_project_cb.SelectedItem == null)
            {
                MessageBox.Show("Bitte ein Projekt auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hole den ausgewählten Projektnamen
            string projektname = suche_project_cb.SelectedItem.ToString();

            // Suche das Projekt anhand des Namens
            var projekt = app.GetProjects().FirstOrDefault(p => p.getProjectName() == projektname);

            // Wenn das Projekt nicht gefunden wurde
            if (projekt == null)
            {
                MessageBox.Show("Projekt nicht gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lese das Tag aus der Textbox (wenn vorhanden)
            string gesuchtesTag = suche_tags_tb.Text.Trim();

            // New
            informationstitel_cb.Items.Clear();

            // Initialisiere einen StringBuilder, um die Informationen zu sammeln
            StringBuilder projektInformationen = new StringBuilder();

            // Füge Informationen des Projekts hinzu
            projektInformationen.AppendLine($"Projekt: {projekt.getProjectName()}");
            projektInformationen.AppendLine("Informationen:");

            // Filtere die Informationen basierend auf dem eingegebenen Tag
            var gefilterteInfos = string.IsNullOrWhiteSpace(gesuchtesTag)
                ? projekt.getProjectInfo() // Falls kein Tag angegeben ist, zeige alle Informationen an
                : projekt.getProjectInfo().Where(info => info.tags.Any(t => t.tag_Name.Equals(gesuchtesTag, StringComparison.OrdinalIgnoreCase))).ToList(); // Nur Infos mit dem passenden Tag anzeigen

            if (!gefilterteInfos.Any())
            {
                projektInformationen.AppendLine("Keine passenden Informationen gefunden.");
            }
            else
            {
                informationstitel_cb.Items.Clear();
                foreach (var info in gefilterteInfos)
                {
                    // New
                    informationstitel_cb.Items.Add(info.getTitle());
                    projektInformationen.AppendLine($"Titel: {info.getTitle()}");
                    projektInformationen.AppendLine($"Datum: {info.date}");

                    // Reguläre Ausdrücke zum Extrahieren von Text, Bild und Dokument
                    string text = info.getText();

                    // Regex zum Extrahieren der Teile: Bild und Dokument
                    string bild = Regex.Match(text, @"Bild: ([^\n]*)").Groups[1].Value;
                    string dokument = Regex.Match(text, @"Dokument: ([^\n]*)").Groups[1].Value;

                    // Nun den Text ohne "Bild:" und "Dokument:" extrahieren
                    string reinerText = text.Split(new string[] { "Bild: ", "Dokument: " }, StringSplitOptions.None)[0];

                    // Jetzt alles in den StringBuilder einfügen
                    projektInformationen.AppendLine($"{reinerText}");
                    projektInformationen.AppendLine($"Bild: {bild}");
                    projektInformationen.AppendLine($"Dokument: {dokument}");

                    projektInformationen.AppendLine("Tags:");
                    foreach (var tag in info.tags)
                    {
                        projektInformationen.AppendLine($"- {tag.tag_Name}");
                    }
                    // New
                    projektInformationen.AppendLine("Kommentare:");
                    if (info.comments != null && info.comments.Any())  // Überprüft, ob Kommentare vorhanden sind
                    {
                        foreach (var comment in info.comments)
                        {
                            projektInformationen.AppendLine($"- {comment}");
                        }
                    }
                    else
                    {
                        projektInformationen.AppendLine("Keine Kommentare vorhanden.");  // Optionaler Hinweis, wenn keine Kommentare existieren
                    }

                    projektInformationen.AppendLine();  // Zeilenumbruch für jede Info
                }
            }

            // Zeige die gesammelten Informationen in der TextBox an
            suche_projektinformation_tb.Text = projektInformationen.ToString();
        }

        private void kommentar_btn_Click(object sender, EventArgs e)
        {
            // Überprüft, ob ein Titel in der ComboBox ausgewählt wurde
            if (informationstitel_cb.SelectedItem == null)
            {
                MessageBox.Show("Bitte einen Informationstitel auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hole den Titel der ausgewählten Information und den Kommentar aus dem Textfeld
            string titel = informationstitel_cb.SelectedItem.ToString();
            string kommentar = kommentar_text_tb.Text.Trim();

            if (string.IsNullOrWhiteSpace(kommentar))
            {
                MessageBox.Show("Kommentar darf nicht leer sein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Finde die Info, zu der der Kommentar hinzugefügt werden soll
            var info = app.GetProjects()
                          .SelectMany(p => p.getProjectInfo())
                          .FirstOrDefault(i => i.getTitle() == titel);

            if (info == null)
            {
                MessageBox.Show("Information nicht gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Füge den Kommentar hinzu
            info.addComment(kommentar);

            // Speichere die Änderungen
            app.Speichern();

            MessageBox.Show("Kommentar erfolgreich hinzugefügt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Leere das Kommentartextfeld
            kommentar_text_tb.Clear();

            // Führe automatisch die Suche aus
            if (suche_project_cb.SelectedItem != null)
            {
                suchen_btn_Click(sender, e);  // Simuliere den Klick auf den Suchen-Button
            }
        }

        private void UpdateComboBox()
        {
            // Verhindere das wiederholte Hinzufügen von Projekten
            if (project_cb.Items.Count == 0)
            {
                project_cb.Items.Clear();
                var projects = app.GetProjects();
                foreach (var project in projects)
                {
                    project_cb.Items.Add(project.getProjectName());
                    suche_project_cb.Items.Add(project.getProjectName());
                }
            }
        }
    }
}
