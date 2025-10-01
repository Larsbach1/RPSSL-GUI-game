README – RPSSL GUI
Formål

Et simpelt spil Rock–Paper–Scissors–Lizard–Spock lavet som GUI i C#.
Bruger klikker på en knap, computeren vælger tilfældigt, og resultatet vises.

Funktioner

5 knapper med valg (🪨 📄 ✂️ 🦎 🖖)

Computer vælger tilfældigt med Random

Vinderen afgøres med switch og enum

Resultat vises i GUI

Scoreboard tæller Player / Computer / Ties

Emoji-feedback på resultat (😀 😢 😐)

Kørsel

Åbn projektmappen og kør:

dotnet run


For at lave en .exe:

dotnet publish -c Release -r win-x64 --self-contained true

Bemærkning

Fundamentet til programmet og ReadMe er lavet med hjælp fra AI, derefter tilpasset til opgaven.
