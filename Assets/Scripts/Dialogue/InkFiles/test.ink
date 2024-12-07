VAR HAS_IRON = "false"
VAR HAS_MIXER = "false"

{HAS_IRON == "false" : {HAS_MIXER == "true" : -> has_mixer | ->main} | ->has_iron}


=== main ===
Maaann, I wanted to open the restaurant by now...  :') #portrait:Andreea_Happy #speaker:Andreea #layout:right
Maaann, I wanted to open the restaurant by now...  :') #portrait:Andreea_Happy #speaker:Andreea #layout:right
But I need a mixer to make Papanasi :/#portrait:Andreea_Happy #speaker:Andreea #layout:right
+ [What's that?]
    ! #speaker:Andreea #portrait:Andreea_Happy #layout:left
    ->papanasi
+ [Can I help somehow?]
    -> here_is_how_you_help
    
    
=== here_is_how_you_help ===
Oh nooo, I wouldn't wan't to take your timeee :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
You probably still have things to unpack ;)  #portrait:Andreea_Happy #speaker:Andreea #layout:right
+ [No, I unpacked my computer, that's basically it] #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Awww you're such a sweetie <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    And wow, I think I'd need 2 weeks to unpack all the stuff I have :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    AT LEAST O-O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    And well, I can make a mixer by putting some stuff inside the box over there :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
    But I don't know where to get the stuff... :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I need iron and a spoon, if you find it , please come back here :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
    If you don't manage to find it , it's also fine :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I'll just ...figure something out, I guess O-O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Thank you <3 <3  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ->DONE
+ [Ah ok, see you later then I guess, gl]
    oh..oke...:( #portrait:Andreea_Happy #speaker:Andreea #layout:right

    ->END
    
=== papanasi ===
    Oh, they are like romanian doghnuts :) filled with cream cheese ;) , jam :O and all things nice :3 #portrait:Papanasi #speaker:Andreea #layout:item
    My grandma used to make them all the time for me when I was in high school :3 #portrait:Papanasi #speaker:Andreea #layout:item
    I don't know how Romania can be recognisable for Andrew Tate and vampires when this stuff exists -_- #portrait:Papanasi #speaker:Andreea #layout:item
    We just have a horrible PR team I guess, lol :D #portrait:Papanasi #speaker:Andreea #layout:item
 ->main
 
 
=== has_iron ===
    Awesomesauce! :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Awesomesauce! :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
    You found the iron! :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Now just put it in the chest and we"ll have a mixer! :3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
->END


=== has_mixer ===
    Alright my little chefs helper! :3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Follow me to the kitchen downstairs! :3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Let's make some romanian doghnuts! :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
 