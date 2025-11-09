# Übung 3: Producer-Consumer Queue

Aufgabe:
1.  Producer erzeugt zufällige Zahlen. 
    - Erstellen Sie in Main() eine ConcurrentQueue.
    - Erweitern Sie den Producer:
       - im Konstruktor wird ein Thread gestartet welcher im Sekundentakt eine zufällige Zahl in die Queue hinzugefügt.
    - Erstellen Sie in der Main() 5 Producer. 
    - Beenden Sie das Programm wenn die Queue mehr als 50 Einträge hat!
2. Consumer:
   - Erweitern Sie den Consumer: 
      - im Konstruktor wird ein Thread gestartet welcher im 250ms Takt eine Zahl aus der Queue auslist und damit eine **Summe** bildet.   
    - Erstellen Sie i der Main() 1 Consumer.   
    - Geben sie in der Main() jede Sekunde den Füllstand der Queue aus.
