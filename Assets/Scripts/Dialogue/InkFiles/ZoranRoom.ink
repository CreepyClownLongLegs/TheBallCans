VAR EPISODE_TWO_FINISHED_RHYTHM_GAME = "false"
VAR EPISODE_ONE_FINISHED_RHYTHM_GAME = "false"
VAR EPISODE_TWO = "false"
VAR HAS_SLINGSHOT = "false"
EXTERNAL giveSlingshot()
EXTERNAL startRhytmGame()

{EPISODE_TWO == "false" : {EPISODE_ONE_FINISHED_RHYTHM_GAME == "false" : -> main | -> gotten_slingshot} | {EPISODE_TWO_FINISHED_RHYTHM_GAME == "false" : -> main | {HAS_SLINGSHOT == "false" : -> game_played | -> gotten_slingshot}}}

=== main ===
<b>That what you did for Andreea...</b> #speaker:Zoran #portrait:default #layout:left
<b>Oh no</b> #speaker:Zoran #portrait:default #layout:left
<b>My dads watchign that stupid show again</b>
~startRhytmGame()
<b>Helps</b> #speaker:Zoran #portrait:default #layout:left
    ->END
    
    
=== game_played ===
<b>That what you did for Andreea...</b> #speaker:Zoran #portrait:default #layout:left
<b>Wow, u really do done played that thing</b> #speaker:Zoran #portrait:default #layout:left
<b>Oh yeah right , Bosnia gave me this, could u bring it back to her?</b> #speaker:Zoran #portrait:default #layout:left
~giveSlingshot()
<b>Thanks man</b> #speaker:Zoran #portrait:default #layout:left
    ->END
    
=== gotten_slingshot ===
<b>That what you did for Andreea...</b> #speaker:Zoran #portrait:default #layout:left
<b>...You should probably get going dude...</b> #speaker:Zoran #portrait:default #layout:left
    ->END
    