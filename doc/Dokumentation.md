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

| Aktivität                   | Stunden geplannt | Stunden geleistet (zusammen) | Delta | Erklärung                                                                                       |
| --------------------------- | ---------------- | ---------------------------- | ----- | ----------------------------------------------------------------------------------------------- |
| Initialisierung und Planung | 1                | 1                            |       |                                                                                                 |
| Kontext Map                 | 1                | 0.5                          | 0.5   | Gab weniger zu tun, da wir die Anforderungen an das Projekt bereits gut verstanden.             |
| Anforderungsanalyse         | 1                | 1                            |       |                                                                                                 |
| Risikoanalyse               | 1                | 0.5                          | 0.5   | Risiken wurden bereits in Anforderungsanalyse besprochen.                                       |
| Kontextdiagramm             | 1                | 0.5                          | 0.5   | Kontextdiagramm konnte an Kontekt Map abgeleitet werden.                                        |
| Kommunikationsdiagramm      | 1                | 0.75                         | 0.25  |                                                                                                 |
| Klassendiagramm             | 1                | 1                            |       |                                                                                                 |
| Testplan                    | 1                | 1                            |       |                                                                                                 |
| Unit-tests                  | 2                | 3                            | 1     | Es tauchten einige Fehler auf beim Schreiben der Tests welche mehr Zeit benötigten als gedacht. |
| Programmierung              | 5                | 7                            | 2     | Fehlersuche hat zum Teil mehr Zeit beansprucht als geplant.                                     |
| Dokumentation               | 3                | 3                            |       |                                                                                                 |
| Präsentation                | 2                |                              |       |                                                                                                 |
| Reserve                     | 2                |                              |       |                                                                                                 |

## Kontext Map

Nach Analyse der Situation undf Ausgangslage hat sich folgende Kontext Map ergeben:

![Kontext Map](/doc/Context_Map.png)

# Kontext Diagramm

Aus der Kontext Map konnte auch das Kontext Diagramm erstellt werden:

![Kontext Diagramm](/doc/Kontextdiagramm.png)

## Kommunikationsdiagramm

Um den Ablauf noch etwas genauer zu verstehen, haben wir auch noch ein Kommunikationsdiagramm erstellt:

![Kommunikationsdiagramm](/doc/Kommunikationsdiagramm.png)

## Klassendiagramm

Anschliessend hatten wir ein genug grosses Verständniss vom Projekt um die Klassen definieren zu können:

![Klassendiagramm](/doc/Classdiagram.png)

## Anforderungsanalyse

In unserem Projekt haben sich folgende Anforderungen und Risiken ergeben:

![Testfälle](/doc/Anforderungen.png)

## Testfälle

Folgende Testfälle wurden definiert und abgearbeitet:

TODO
![Testfälle](/doc/Testfaelle.png)

## Realisation

In unserer Applikation haben wir zuerst das UI mit Windows Forms erstellt:

![UI](/doc/UI.png)

Dabei haben wir uns für drei Tabs entschieden:

- Projekterstellung
- Informationserstellung
- Suchen/Kommentieren

Anschliessend wurden die Klassen anhand des Klassendiagramms geschrieben.
Damit hatten wir bereits einen soliden Aufbau des Projekts.

Nach den Klassen haben wir uns gedanken gemacht, welche Funktionen alles benötigt werden. Dabei haben wir folgende Funktionen erstellt:

- NeuesProjektErstellen
- NeueInformationHinzufuegen
- InformationenSuchen
- Speichern
- Laden

Mit diesen Funktionen können wir alle Funktionen unseres Wissensmanagement abbilden.
