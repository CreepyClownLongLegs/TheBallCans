VAR EPISODE_TWO_FINISHED_COOKING_GAME = "false"

{EPISODE_TWO_FINISHED_COOKING_GAME == "false" : -> cant_start_quest | -> main}

===main===
<b>My grandpa is watching that show again</b> #speaker:Zoran #portrait:default #layout:left
<b>My grandpa is watchignt that hshow again...</b> #speaker:Zoran #portrait:default #layout:left
<b>...</b> #speaker:Zoran #portrait:default #layout:left
<b>Your assistance may be required upstairs</b> #speaker:Zoran #portrait:default #layout:left
    ->END
    
===cant_start_quest===
<b>Hi new kid</b> #speaker:Zoran #portrait:default #layout:left
<b>Hi new kid</b> #speaker:Zoran #portrait:default #layout:left
<b>Im busy grumpling now </b> #speaker:Zoran #portrait:default #layout:left
<b>Come back later</b> #speaker:Zoran #portrait:default #layout:left
    ->END
    
