INCLUDE globals.ink
VAR HAS_IRON = "false"
VAR HAS_SPOON = "false"

EXTERNAL takeIron()
EXTERNAL takeSpoon()
EXTERNAL giveMixer()

{HAS_SPOON == false : -> missingItems | -> giveMixerDialogue}

=== missingItems ===
I still don't have all the items. #speaker: Player #portrait: Player #layout: left
I still don't have all the items. Gotta keep looking. #speaker: Player #portrait: Player #layout: left
->END

=== giveMixerDialogue ===
Oh great! #speaker: Chest #portrait: Chest #layout: right
Oh great! You collected all the items! #speaker: Chest #portrait: Chest #layout: right
~takeIron()
~takeSpoon()
Let's send them to Germany to give us an upgrade in the Kitchen! #speaker: Chest #portrait: Chest #layout: right
~giveMixer()
This will come in handy in the Kitchen! :D #speaker: Player #portrait: Player #layout: left
->END