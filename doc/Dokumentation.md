# Wissensmanagement

Projekt von Marcel Borter und Dominic Rohner

Fach: Lösungsalgorithmen

Dozent: Christian Herren

## Situationsanalyse

Die IT-Firma Xarelto möchte ein Wissensmanagementsystem einführen, um die Effizienz und den Wissensaustausch in Projekten zu verbessern.
Der Projektleiter (PL) kann ein neues Projekt starten und grundlegende Informationen zum Projekt abgeben.
Während dem Projekt kann das Team neue Informationen zum Projekt hinzufügen, wie Texte, Bilder (URL) und andere Dokumente (URL).
Die Information kann mit maximal drei Tags gekennzeichnet werden.
Es sollten auch nachträglich Kommentare zu den Projektinformationen hinzugefügt werden können. Diese sollen jedoch kalr vom Originaltext abgegrenzt werden.
Durch die Möglichkeit, nach Tags zu suchen, wird das Finden relevanter Informationen erleichtert.

## Planung

Zu Beginnn unseres Projektes haben wir alle Tätigkeiten aufgelistet und die dafür benötigte Zeit geschätzt.
In der nachfolgenden Tabelle sind alle geschätzten und effektiv geleisteten Stunden ersichtlich:

| Aktivität                   | Stunden geplannt | Stunden geleistet (zusammen) | Delta | Erklärung                                                   |
| --------------------------- | ---------------- | ---------------------------- | ----- | ----------------------------------------------------------- |
| Initialisierung und Planung | 1                | 1                            |       |                                                             |
| Context Map                 | 1                | 0.5                          |       |                                                             |
| Anforderungsanalyse         | 1                | 1                            |       |                                                             |
| Risikoanalyse               | 1                | 0.5                          |       |                                                             |
| Kontextdiagramm             | 1                | 0.5                          |       |                                                             |
| Kommunikationsdiagramm      | 1                | 0.75                         |       |                                                             |
| Klassendiagramm             | 1                | 1                            |       |                                                             |
| Testplan                    | 1                | 1                            |       |                                                             |
| Unit-tests                  | 2                |                              |       |                                                             |
| Programmierung              | 5                | 7                            | 2     | Fehlersuche hat zum Teil mehr Zeit beansprucht als gedacht. |
| Dokumentation               | 3                |                              |       |                                                             |
| Präsentation                | 2                |                              |       |                                                             |
| Reserve                     | 2                |                              |       |                                                             |

## Kontext Map

Nach Analyse der Situation hat sich folgende Kontext Map ergeben:

![Kontext Map](/doc/Context_Map.png)

# Kontext Diagramm

Aus der Kontext Map konnte auch das Kontext Diagramm abgeleitet werden:

![Kontext Diagramm](/doc/Kontextdiagramm.png)

## Kommunikationsdiagramm

Um den Ablauf noch etwas genauer zu verstehen, haben wir auch noch ein Kommunikationsdiagramm erstellt:

![Kommunikationsdiagramm](/doc/Kommunikationsdiagramm.png)

## Klassendiagramm

Anschliessend hatten wir ein genug grosses Verständnigss vom Projekt, damit wir die Klassen definieren konnten:

![Klassendiagramm](/doc/Classdiagram.png)

## Anforderungsanalyse

Alle Anforderungen wurden aufgelistet. In unserem Projekt haben sich folgende Anforderungen und Risiken ergeben:

TODO

## Testfälle

Folgende Testfälle wurden definiert und abgearbeitet:

TODO
![Testfälle](/doc/Testfaelle.png)

## Realisation

In unserer Appliaktion haben wir zuerst das UI mit Windows Forms erstellT:

TODO
![UI](/doc/UI.png)

Anschliessend wurden die Klassen anhand des Klassendiagramms geschrieben.
