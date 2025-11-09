# Übung 1: Zwei Threads – Zählen & Winner
Beschreibung:
1. Implementiere folgende zwei Threads
   - Thread A zählt von 1 bis 100 (100ms Takt).
   - Thread B zählt von 100 bis 1 (100ms Takt).
2. Wenn beide die gleiche Zahl erreichen, sollen beide stoppen und DONE ausgeben.
3. Danach soll derjenige, der schneller gezählt hat, WINNER schreiben.

Struktur:
- Program.cs: Startpunkt, erstellt zwei Threads.
- Schüler sollen Synchronisation (lock oder Monitor) implementieren.
