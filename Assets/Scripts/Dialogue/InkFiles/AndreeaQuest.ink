INCLUDE globals.ink
VAR EPISODE_ONE_FINISHED_COOKING_GAME = "false"
VAR ACCEPTED_QUEST_YET = "false"
EXTERNAL startEpisodeOneCookingGame()
EXTERNAL UnlockSerbiaRoom()

{ACCEPTED_QUEST_YET == "false" : -> not_ready_to_play | { EPISODE_ONE_FINISHED_COOKING_GAME == "false": -> main | -> already_played }}

=== not_ready_to_play===
Hi new guy, I"m super stressed now, can you come back later :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
Hi new guy, I"m super stressed now, can you come back later :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right

    -> END

=== main ===
Please help with cooking, I'm dying :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
Please help with cooking, I'm dying :(  #portrait:Andreea_Happyy #speaker:Andreea #layout:right

~startEpisodeOneCookingGame()
    
    -> END

=== already_played ===
You were a great help traveller! :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
You were a great help traveller! :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
Collect Your pay at the tezga :D

    -> END