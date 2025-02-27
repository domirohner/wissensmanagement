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
        // Attribute
        public string tag_Name;

        // Konstruktor
        public Tag(string tag_Name)
        {
            this.tag_Name = tag_Name;
        }
    }

    [Serializable]
    public class Info
    {
        // Attribute
        public string title;
        public string text;
        public string date;
        public List<Tag> tags;
        public List<string> comments = new List<string>();

        // Konstruktor
        public Info(string title, string text, string date, List<Tag> tags)
        {
            this.title = title;
            this.text = text;
            this.date = date;
            this.tags = tags ?? new List<Tag>();
            this.comments = new List<string>();
        }

        // Methoden
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
                comments = new List<string>();
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
        // Attribute
        public string project_Name;
        public List<Info> project_Info = new List<Info>();
        public List<Tag> project_Tags = new List<Tag>();

        // Konstruktor
        public Project(string project_Name)
        {
            this.project_Name = project_Name;
        }

        // Methoden
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
        public bool IsTestMode { get; set; } = false;

        private string SpeicherDatei;

        // Definition Speicherort (es muss ein C:\Temp existieren)
        // Dadurch kann der Speicherort spezifiziert werden
        public WissensmanagementApp(string speicherDatei = "C:\\Temp\\projects.dat")
        {
            SpeicherDatei = speicherDatei;
        }

        // Erstellung neues Projekt
        public void NeuesProjektErstellen(string projektName)
        {
            var projekt = new Project(projektName);
            projects.Add(projekt);
            Speichern();
            if (!IsTestMode)
            {
                MessageBox.Show("Projekt erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<Project> GetProjects()
        {
            return projects;
        }
        // Information hinzufügen
        public void NeueInformationHinzufuegen(string projektName, string title, string text, string date, List<Tag> tags)
        {
            var projekt = projects.FirstOrDefault(p => p.project_Name == projektName);
            // Fehler ausgeben wenn Projekt nicht gefunden wird
            if (projekt == null)
            {
                if (!IsTestMode)
                {
                    MessageBox.Show("Projekt nicht gefunden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            var info = new Info(title, text, date, tags);
            // Info hinzufügen
            projekt.addInfo(info);
            Speichern();
            if (!IsTestMode)
            {
                MessageBox.Show("Information erfolgreich hinzugefügt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Information suchen
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
                // Information ausgeben
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
        // Speichern in definierte Datei
        public void Speichern()
        {
            // Schreibt in Dataei
            using (var stream = new FileStream(SpeicherDatei, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, projects);
            }
        }
        // Laden der definierten Datei
        public void Laden()
        {
            // Prüft ob Datei exisitert
            if (File.Exists(SpeicherDatei))
            {
                using (var stream = new FileStream(SpeicherDatei, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    projects = (List<Project>)formatter.Deserialize(stream);
                }
            }
        }
        // Main
        public static void Main(string[] args)
        {
            // App laden
            var app = new WissensmanagementApp();
            app.Laden();

            // GUI initializieren
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Starte Form1
            Application.Run(new Form1(app));
        }
    }
    // Definition Form Klasse
    public partial class Form1 : Form
    {
        private WissensmanagementApp app;

        public Form1(WissensmanagementApp app)
        {
            // Initialisierung
            InitializeComponent();
            this.app = app;
        }

        // Update Combo Box mit Projekten beim Laden
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
        }
        // Klicken des Projekt erstellen Button
        private void create_project_Click(object sender, EventArgs e)
        {
            string projektname = projektname_tb.Text;

            // Fehlermeldung ausgeben wenn Projektname leer ist
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
        // Klicken des Information hinzufügen Button
        private void information_hinzufuegen_btn_Click(object sender, EventArgs e)
        {
            // Gib Fehlermeldung aus wenn kein Projekt gewählt ist
            if (project_cb.SelectedItem == null)
            {
                MessageBox.Show("Bitte ein Projekt auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Erhalte Werte des Projekts
            string projektname = project_cb.SelectedItem.ToString();
            string title = information_text_tb.Text.Length > 10 ? information_text_tb.Text.Substring(0, 10) : information_text_tb.Text;
            string text = $"Text: {information_text_tb.Text}\nBild: {information_bilder_tb.Text}\nDokument: {information_dokumente_tb.Text}";
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Tag> tags = informationen_tags_tb.Text.Split(',').Select(t => new Tag(t.Trim())).ToList();

            // Füge Information hinzu
            app.NeueInformationHinzufuegen(projektname, title, text, date, tags);

            // Felder leeren
            information_text_tb.Clear();
            information_bilder_tb.Clear();
            information_dokumente_tb.Clear();
            informationen_tags_tb.Clear();

        }
        // Klicken Suchen Button
        private void suchen_btn_Click(object sender, EventArgs e)
        {
            // Lade die gespeicherten Projekte aus der Datei
            app.Laden();

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

            informationstitel_cb.Items.Clear();

            // Initialisiere einen StringBuilder, um die Informationen zu sammeln
            StringBuilder projektInformationen = new StringBuilder();

            // Füge Informationen des Projekts hinzu
            projektInformationen.AppendLine($"Projekt: {projekt.getProjectName()}");
            projektInformationen.AppendLine("Informationen:");

            // Filtere die Informationen basierend auf dem eingegebenen Tag
            var gefilterteInfos = string.IsNullOrWhiteSpace(gesuchtesTag)
                ? projekt.getProjectInfo()
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
                    informationstitel_cb.Items.Add(info.getTitle());
                    projektInformationen.AppendLine($"Titel: {info.getTitle()}");
                    projektInformationen.AppendLine($"Datum: {info.date}");

                    string text = info.getText();

                    // Regex zum Extrahieren der Teile: Bild und Dokument
                    string bild = Regex.Match(text, @"Bild: ([^\n]*)").Groups[1].Value;
                    string dokument = Regex.Match(text, @"Dokument: ([^\n]*)").Groups[1].Value;

                    // Nun den Text ohne "Bild:" und "Dokument:" extrahieren
                    string reinerText = text.Split(new string[] { "Bild: ", "Dokument: " }, StringSplitOptions.None)[0];

                    // Werte ausgeben
                    projektInformationen.AppendLine($"{reinerText}");
                    projektInformationen.AppendLine($"Bild: {bild}");
                    projektInformationen.AppendLine($"Dokument: {dokument}");

                    projektInformationen.AppendLine("Tags:");
                    foreach (var tag in info.tags)
                    {
                        projektInformationen.AppendLine($"- {tag.tag_Name}");
                    }
                    projektInformationen.AppendLine("Kommentare:");
                    if (info.comments != null && info.comments.Any())
                    {
                        foreach (var comment in info.comments)
                        {
                            projektInformationen.AppendLine($"- {comment}");
                        }
                    }
                    else
                    {
                        projektInformationen.AppendLine("Keine Kommentare vorhanden.");
                    }
                    // Zeilenumbruch für jede Info
                    projektInformationen.AppendLine();
                }
            }

            // Zeige die Informationen in der TextBox an
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
        // Update der Combo Box mit Projekten
        private void UpdateComboBox()
        {
            project_cb.Items.Clear();
            suche_project_cb.Items.Clear();

            // Erhalte alle Projekte
            var projects = app.GetProjects();
            // Füge Projekte hinzu
            foreach (var project in projects)
            {
                project_cb.Items.Add(project.getProjectName());
                suche_project_cb.Items.Add(project.getProjectName());
            }
        }

    }
}
