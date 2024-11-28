INCLUDE globals.ink
VAR EPISODE_ONE_FINISHED_COOKING_GAME = "false"
EXTERNAL startEpisodeOneCookingGame()
EXTERNAL UnlockSerbiaRoom()

{ EPISODE_ONE_FINISHED_COOKING_GAME == "false": -> main | -> already_played }

=== main ===
Please help with cookint, I'm dying :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
Please help with cookint, I'm dying :(  #portrait:Andreea_Happyy #speaker:Andreea #layout:right

~startEpisodeOneCookingGame()
    
    -> END

=== already_played ===
You were a great help traveller!#portrait:Andreea_Happy #speaker:Andreea #layout:right
You were a great help traveller!#portrait:Andreea_Happy #speaker:Andreea #layout:right
~UnlockSerbiaRoom()
Collect Your pay at the tezga

    -> END