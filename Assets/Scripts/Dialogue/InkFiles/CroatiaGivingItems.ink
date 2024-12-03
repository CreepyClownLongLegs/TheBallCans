INCLUDE globals.ink

EXTERNAL giveIron()
EXTERNAL giveSpoon()
VAR HAS_SPOON = "false"
VAR HAS_IRON = "false"
VAR EPISODE_TWO = "false"

{EPISODE_TWO == "false" : -> main | {HAS_IRON == "true" : -> already_bought | -> buy_items}}

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
    
=== main ===
Finally a new job. #speaker: JosipNPC #layout: right
Finally a new job. #speaker: JosipNPC #layout: right
I hope I keep this one, last one was too much for me.
Do you want to hear my story?
+ [No, loser. Get back to work.]
    Oh- okay... Sorry. #speaker: JosipNPC #layout: right
    ->DONE
+ [Sure, I got some time.]
    Well, my former boss wanted me to stop shitting my pants. #speaker: JosipNPC #layout: right
    Can you believe that?!
    ->END
    
=== already_bought ===
Bruh I gotta shit so bad. #speaker: JosipNPC #layout: right
Bruh I gotta shit so bad. #speaker: JosipNPC #layout: right
    -> END