VAR EPISODE_ONE_FINISHED_COOKING_GAME = "false"
VAR ACCEPTED_QUEST_YET = "false"
EXTERNAL startEpisodeOneCookingGame()
EXTERNAL UnlockSerbiaRoom()
{EPISODE_ONE_FINISHED_COOKING_GAME == "false" : -> no_finished_helping_Romania | -> main}

===main===
<b>That what you did for Andreea...</b> #speaker:Zlatan #portrait:default #layout:left
<b>That what you did for Andreea...</b> #speaker:Zlatan #portrait:default #layout:left
<b>Was pretty nice...</b>
<b>You're alrigtht kid</b>
~UnlockSerbiaRoom()
<b>Drop by sometime</b> #speaker:Zlatan #portrait:default #layout:left

    ->END
    
===no_finished_helping_Romania===
<b>Hi new kid</b> #speaker:Zlatan #portrait:default #layout:left
<b>Hi new kid</b> #speaker:Zlatan #portrait:default #layout:left
    ->END