INCLUDE globals.ink

EXTERNAL giveIron()
EXTERNAL giveSpoon()
VAR HAS_SPOON = "false"
VAR HAS_IRON = "false"
VAR EPISODE_TWO = "false"
VAR ACCEPTED_QUEST_YET_EPISODE_TWO = "false"

{EPISODE_TWO == "false" : -> main | { ACCEPTED_QUEST_YET_EPISODE_TWO == "false" :  -> talk_to_Andreea_first | {HAS_IRON == "true" : -> already_bought | -> buy_items}}}

=== buy_items ===
Yo.
Yo, kid! #speaker: Josip #portrait: Josip #layout: right
I heard you're looking for... special items ;)
Come over here, I'll give you some.
This one is really special. My mom used to - well - discipline me with.
~giveSpoon()

This one, my dad threw at me when I was six.
It hit my head pretty hard. But the coma was a well deserved rest.
I was ready to hit the coal mines in no time after that.
~giveIron()
I wonder if that made me the way I am now.
    -> END
    
=== talk_to_Andreea_first ===
I heard theres stuff for this...like the opposite of laxatives... #speaker: Josip #layout: right
I heard theres stuff for this...like the opposite of laxatives... #speaker: Josip #layout: right 
What was it again... #speaker: Josip #layout: right
Oh hi there, haha #speaker: Josip #layout: right
I was just talking to myself #speaker: Josip #layout: right
Btw, Andreea seemed really distressed this morning #speaker: Josip #layout: right
Maybe you should go talk to her idk #speaker: Josip #layout: right
    ->END
    
=== main ===
Finally a new job. #speaker: Josip #layout: right
Finally a new job. #speaker: Josip #layout: right
I hope I keep this one, last one was too much for me.
Do you want to hear my story?
+ [No, loser. Get back to work.]
    Oh- okay... Sorry. #speaker: Josip #layout: right
    ->DONE
+ [Sure, I got some time.]
    Well, my former boss wanted me to stop shitting my pants. #speaker: Josip #layout: right
    Can you believe that?!
    ->END
    
=== already_bought ===
Bruh I gotta shit so bad. #speaker: Josip #layout: right
Bruh I gotta shit so bad. #speaker: Josip #layout: right
    -> END