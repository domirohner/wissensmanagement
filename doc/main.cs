using System;

namespace Wissensmanagement
{
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
    public class Info
    {
        // Attributes
        public string title;
        public string text;
        public string date;
        public list<Tag> tags;
        // Constructor
        public Info(string title, string text, string date, list<Tag> tags)
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
    public class Project
    {
        // Attributes
        public string project_Name;
        public list<Info> project_Info;
        public list<Tag> project_Tags;
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
        public list<Info> getProjectInfo()
        {
            return project_Info;
        }
        public list<Tag> getProjectTags()
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

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}