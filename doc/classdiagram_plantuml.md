@startuml

class Tag {
    +tag_Name: string
    +Tag(tag_Name: string)
}

class Info {
    +title: string
    +text: string
    +date: string
    +tags: List<Tag>
    +comments: List<string>
    +addTag(tag: Tag)
    +removeTag(tag: Tag)
    +addComment(comment: string)
    +getText(): string
    +getTitle(): string
}

class Project {
    +project_Name: string
    +project_Info: List<Info>
    +project_Tags: List<Tag>
    +getProjectName(): string
    +getProjectInfo(): List<Info>
    +getProjectTags(): List<Tag>
    +addInfo(info: Info)
    +removeInfo(info: Info)
    +addTag(tag: Tag)
    +removeTag(tag: Tag)
}

class WissensmanagementApp {
    +projects: List<Project>
    +NeuesProjektErstellen(projektName: string)
    +GetProjects(): List<Project>
    +NeueInformationHinzufuegen(projektName: string, title: string, text: string, date: string, tags: List<Tag>)
    +InformationenSuchen()
    +Speichern()
    +Laden()
}

WissensmanagementApp "1" -- "*" Project : beinhaltet
Project "1" -- "*" Info : hat
Info "1" -- "3" Tag : zugeteilt