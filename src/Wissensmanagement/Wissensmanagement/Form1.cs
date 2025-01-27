using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Wissensmanagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void create_project_Click(object sender, EventArgs e)
        {
            string projektname = projektname_tb.Text;
        }
    }

    [Serializable]
    public class Tag
    {
        // Attributes
        public string tag_Name;
        //Constructor
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
        // Constructor
        public Info(string title, string text, string date, List<Tag> tags)
        {
            this.title = title;
            this.text = text;
            this.date = date;
            this.tags = tags;
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
        public List<Info> project_Info;
        public List<Tag> project_Tags;
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

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
