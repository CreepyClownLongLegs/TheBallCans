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
I just have way too much to do :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    +[Can I help?]
    Ah you know, usually I wouldn't take help from somebody new :/  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    But my grandma got a cold and can't get out of bed :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    So I have no other help today :C #portrait:Andreea_Happy #speaker:Andreea #layout:right
    But look around the kitchen  :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
    If you find something you can do please come to me and tell me :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
        ->DONE
    +[Ok, I'll come later]
    Oh oke :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    See you later then :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Hope you drop by again sometime soon :)  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    And try our food :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
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
Did you find something  you can do? :)  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    +[I could bring you the ingreedients]
    That actually sounds amazing, because walking all over the place it taking so much time :') #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Alright; to the kitchen then :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Chefs helper ;) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ~startEpisodeOneCookingGame()
    ->DONE
    
    +[I could help with cooking]
    Alright; to the kitchen then :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Chefs helper ;) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ~startEpisodeOneCookingGame()
    ->DONE

    
    -> END

=== already_played ===
You were a great help traveller! :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
The Sarmale you helped me make turned out awesome! :)#portrait:Sarmale #speaker:Andreea #layout:item
And such a great helper as yourself deserves to get paid :D #portrait:Sarmale #speaker:Andreea #layout:item
I left your hourly pay at the tezga and a little bit extra ;) #portrait:Andreea_Happy #speaker:Andreea #layout:right
Making Sarmale has really made me melacholic about the time Fatima, me and Jelena made a trip to Bucharest:D #portrait:Andreea_Happy #speaker:Andreea #layout:right
We went to Bucharest and visited the Antheneum , a huge beautiful theater with old painting in it :O #portrait:Antheneum #speaker:Andreea #layout:item
Thats basically the heart of Bucharest, and also the place where I had my high school prom :D #portrait:Antheneum #speaker:Andreea #layout:item
haha :) #portrait:Antheneum #speaker:Andreea #layout:item
Thank God that's over... :) #portrait:Antheneum #speaker:Andreea #layout:item
We took this picture there on our trip :) #portrait:UsInRomania #speaker:Andreea #layout:item
Cool right :D #portrait:UsInRomania #speaker:Andreea #layout:item
But not as cool as the Sarmale we had afterwards, mad we could barely move for an hour after eating it O-O portrait:UsInRomania #speaker:Andreea #layout:item
We were in a trans! :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
And afterwards there was this light show in the center of Bucharest we saw on our way home :D #portrait:SpotLightFestival #speaker:Andreea #layout:item
And everybody around us was dancing, it was also the first time for me to see that :O #portrait:SpotLightFestival #speaker:Andreea #layout:item
Since i grew up in a small village next to Bucharest :) #portrait:SpotLightFestival #speaker:Andreea #layout:item
We thought they might've put something in the Sarmale and now we were seeing things lol :'D  #portrait:SpotLightFestival #speaker:Andreea #layout:item

    +[Is it safe to go there tho?]
    Why wouldn't it be? :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Ah ok, you mean because of ALL THE CRIME happening in Romania? :C #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Honestly, I don't know where that stereotype comes from :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Romania isn't any less safe then any other country in Europe :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Ok, maybe a bit less safe than Austria :P #portrait:Andreea_Happy #speaker:Andreea #layout:right
    But its safer than France and other places booming with tourists :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I feel like, people might be getting this image of us because of all the media always mentioning our nationality first when somebody from out country does something :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    But if a person from a country that doesn't have such a bad reputation does somthing the headline usually isn't going to be :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    "Person from this country killed 2 people" but rather just :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    "2 people have been killed" :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    So you are not likely to immidietely associate the people from that country with the crime being commited :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ... :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    sorry to keep on rambling... :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I am just really tired of seeing us beeing represented this way here... :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    And also seeing the reaction on peoples faces whenever they hear that I am from Romania :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Sorry... :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    You probably didnt have any bad implication :* #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Please drop by my place tommorow for some Papanasi <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I wan't you to feel welcome here with us <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ->DONE
    +[That sounds awesome]
    YES IT WAASS!!! :D  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Please drop by my place tommorow for some Papanasi <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I wan't you to feel welcome here with us <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ->DONE

    -> END

===already_played_episode_two===
You were a great help traveller! :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
You were a great help traveller! :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
Collect Your pay at the tezga :D

    -> END