VAR EPISODE_TWO_FINISHED_COOKING_GAME = "false"

{EPISODE_TWO_FINISHED_COOKING_GAME == "false" : -> cant_start_quest | -> main}

===main===
<b>My grandpa is watching that show again</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>My grandpa is watchignt that hshow again...</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>...</b> #speaker:Zoran #portrait:Zlatan_happy #layout:left
<b>Your assistance may be required upstairs</b> #speaker:Zlatan #portrait:defZlatan_happyault #layout:left
    ->END
    
===cant_start_quest===
<b>Hi new kid</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>Hi new kid</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>Im busy grumpling now </b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>Come back later</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
    ->END
    
