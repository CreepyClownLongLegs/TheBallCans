INCLUDE globals.ink
VAR EPISODE_ONE_FINISHED_COOKING_GAME = "false"
VAR ACCEPTED_QUEST_YET = "false"
VAR EPISODE_TWO = "false"
VAR HAS_MIXER = "false"
VAR EPISODE_TWO_FINISHED_COOKING_GAME = "false"
EXTERNAL startEpisodeOneCookingGame()
EXTERNAL UnlockSerbiaRoom()
EXTERNAL takeMixer()

{EPISODE_TWO == "true" : { HAS_MIXER == "true" : {EPISODE_TWO_FINISHED_COOKING_GAME == "true" : -> already_played_episode_two | -> episode_two_play_game}| -> not_ready_to_play} |  {ACCEPTED_QUEST_YET == "false" : -> not_ready_to_play | { EPISODE_ONE_FINISHED_COOKING_GAME == "false": -> main | -> already_played }}}

=== not_ready_to_play===
Hi new guy, I"m super stressed now, can you come back later :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
Hi new guy, I"m super stressed now, can you come back later :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right

    -> END
    
=== no_mixer ===
Where do I get a mixer?!? :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
Where do I get a mixer?!? :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right

    -> END
    
=== episode_two_play_game===
Please help with cooking, I'm dying :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
Please help with cooking, I'm dying :(  #portrait:Andreea_Happyy #speaker:Andreea #layout:right

Ok awesaume Sauce!! U got the mixer!
~takeMixer()
Let the cooking begin!!

~startEpisodeOneCookingGame()
    ->END

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

===already_played_episode_two===
You were a great help traveller! :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
You were a great help traveller! :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
Collect Your pay at the tezga :D

    -> END