# Tentamen i Clean code och testbar kod

- Datum: 2021-01-21
- Program: C#-utvecklare
- Elev: Wilhelm Berggren

## Redovisning
### Vad du valt att testa och varför?
Jag valde testa: 
- Controllerns `TopList`, samt båda sorteringsordningarna
- Controllerns `GetMovieById`
- Konverteringen från modellen `DetailedMovie` till `Movie`
- Kombineringen av de två källorna
- Att båda datakällorna är åtkomstbara och returnerar ett icke-tomt värde.

Testningen underlättades genom att mocka mina repositories, och använda kontrollern direkt med dem.

### Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt?
Utöver de mönster som är standard i ASP.NET, som Services och Dependency Injection, har jag valt att använda Repository-mönstret. En anledning till det är för att koppla isär kontrollern ifrån datahämtningen. En annan är för att abstrahera bort faktumet att det finns flera datakällor från kontrollern, eftersom det inte är dess ansvar.

De tre repositorna är:
- SimpleMovieRepository: Hämtar data från den första endpointen och deserialiserar det till Movie-modellen.
- DetailedMovieRepository: Hämtar data från den andra endpointen och deserialiserar det till DetailedMovie-modellen.
- MovieRepository: Den som direkt används av controllern, och vars ansvar det är att kombinera de andra repositorerna.

Ett annat mönster jag kunde ha använt är Object Pool-mönstret. En brist med koden nu är att data hämtas från båda datakällorna vid varje request. Om man istället hade en Pool som är anknyten till något objekt som bestämmer hur ofta datan skall uppdateras, och delar ut instanser av dessa, kan man ha mer kontroll över hur ofta denna datan uppdateras.

### Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?
Fokus var på att göra koden lättförstådd och decouplad, och att inte överabstrahera. Om programmet behövde användas av tusentals människor och använda tusentals filmer, hade programmet behövt till exempel en lösning för cachning och pagination. Man kanske också hade velat dela ut tokens för att förhindra överbelastning från en viss användare.