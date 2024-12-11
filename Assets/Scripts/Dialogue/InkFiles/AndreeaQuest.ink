INCLUDE globals.ink
VAR EPISODE_ONE_FINISHED_COOKING_GAME = "false"
VAR ACCEPTED_QUEST_YET = "false"
VAR EPISODE_TWO = "false"
VAR HAS_MIXER = "false"
VAR EPISODE_TWO_FINISHED_COOKING_GAME = "false"
EXTERNAL spotlightVideo()
EXTERNAL startEpisodeOneCookingGame()
EXTERNAL UnlockSerbiaRoom()
EXTERNAL takeMixer()

{EPISODE_TWO == "true" : { HAS_MIXER == "true" : {EPISODE_TWO_FINISHED_COOKING_GAME == "true" : -> already_played_episode_two | -> episode_two_play_game}| -> no_mixer} |  {ACCEPTED_QUEST_YET == "false" : -> not_ready_to_play | { EPISODE_ONE_FINISHED_COOKING_GAME == "false": -> main | -> already_played }}}

=== not_ready_to_play===
Hi new guy, I'm super stressed now, can you come back later :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
Hi new guy, I'm super stressed now, can you come back later :(  #portrait:Andreea_Happy #speaker:Andreea #layout:right
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
Ok awesomeOk awesomesauce!! U got the mixer! #portrait:Andreea_Happy #speaker:Andreea #layout:right
Ok awesomesauce!! U got the mixer! #portrait:Andreea_Happy #speaker:Andreea #layout:right
~takeMixer()
Let the cooking begin!! #portrait:Andreea_Happy #speaker:Andreea #layout:right

~startEpisodeOneCookingGame()
    ->END

=== main ===
Did you find something  you can do? :)  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    +[I could bring you the ingredients]
    That actually sounds amazing, because walking all over the place takes so much time :') #portrait:Andreea_Happy #speaker:Andreea #layout:right
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
Making Sarmale has really made me melacholic about the time Fatima, me and Jelena made a trip to Bucharest :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
We went to Bucharest and visited the Antheneum, a huge beautiful theater with old paintings in it :O #portrait:Antheneum #speaker:Andreea #layout:item
Thats basically the heart of Bucharest, and also the place where I had my high school prom :D #portrait:Antheneum #speaker:Andreea #layout:item
haha :) #portrait:Antheneum #speaker:Andreea #layout:item
Thank God that's over... :) #portrait:Antheneum #speaker:Andreea #layout:item
We took this picture there on our trip :) #portrait:UsInRomania #speaker:Andreea #layout:item
Cool right :D #portrait:UsInRomania #speaker:Andreea #layout:item
But not as cool as the Sarmale we had afterwards, man we could barely move for an hour after eating it O-O #portrait:UsInRomania #speaker:Andreea #layout:item
We were in a trans! :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
And afterwards there was this light show in the center of Bucharest we saw on our way home :D #portrait:SpotLightFestival #speaker:Andreea #layout:item
And everybody around us was dancing, it was also the first time for me to see that :O #portrait:SpotLightFestival #speaker:Andreea #layout:item
Since i grew up in a small village next to Bucharest :) #portrait:SpotLightFestival #speaker:Andreea #layout:item
We thought they might've put something in the Sarmale and now we were seeing things lol :'D  #portrait:SpotLightFestival #speaker:Andreea #layout:item

    +[Is it safe to go there tho?]
    Why wouldn't it be? :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Ah ok, you mean because of ALL THE CRIME happening in Romania? :C #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Honestly, I don't know where that stereotype comes from :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Romania isn't any less safe than any other country in Europe :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Ok, maybe a bit less safe than Austria :P #portrait:Andreea_Happy #speaker:Andreea #layout:right
    But its safer than France and other places booming with tourists :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I feel like people might be getting this image of us because of all the media always mentioning our nationality first when somebody from our country does something :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    But if a person from a country that doesn't have such a bad reputation does something, the headline usually isn't going to be :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    "Person from this country killed 2 people" but rather just :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    "2 people have been killed" :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    So you are not likely to immediately associate the people from that country with the crime being commited :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ... :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    sorry to keep on rambling... :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I am just really tired of seeing us being represented this way here... :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
    And also seeing the reaction on peoples faces whenever they hear that I am from Romania :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Sorry... :( #portrait:Andreea_Happy #speaker:Andreea #layout:right
    You probably didnt have any bad implication :* #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Please drop by my place tommorow for some Papanasi <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I want you to feel welcome here with us <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ->DONE
    +[That sounds awesome]
    YES IT WAASS!!! :D  #portrait:Andreea_Happy #speaker:Andreea #layout:right
    Please drop by my place tommorow for some Papanasi <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I want you to feel welcome here with us <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ->DONE

    -> END

===already_played_episode_two===
And you just keep getting better and better don't you :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
And you just keep getting better and better don't you :)#portrait:Andreea_Happy #speaker:Andreea #layout:right
Maybe you should consider opening your own romanian specialties restaurant <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
Or just come working for me hehe ;) #portrait:Andreea_Happy #speaker:Andreea #layout:right
Eating Papanasi always reminds of the Michael Jackson monument in Bucharest. #portrait:Andreea_Happy #speaker:Andreea #layout:right
    +[the Michael Jackson what in Bucharest?]
    ->michale_jakson_monument
    ->DONE
    +[Oh yeah, I was there too!]
    Really? That's so cool :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
    I remember it being pretty close to the parliament Castle :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
    ->parliament_castle

    -> END

===michale_jakson_monument===
Yeah haha, we errected a Michael Jackson memorial at Herastrau Park! ;) #portrait:MichaelJackson #speaker:Andreea #layout:item
That's the biggest park in Bucharest. :D #portrait:MichaelJackson #speaker:Andreea #layout:item
I didn't go there much in highschool, but friends of me did. :') #portrait:MichaelJackson #speaker:Andreea #layout:item
They say it's pretty awesome. :) #portrait:MichaelJackson #speaker:Andreea #layout:itemt
    ->parliament_castle
->END
    
===parliament_castle===
The Parliament Castle also looks insane. >:) #portrait:Parlament #speaker:Andreea #layout:item
Even tho we call it a castle, its been made pretty recently - about a hundred years ago! o-O #portrait:Parlament #speaker:Andreea #layout:item
With about 700 architects. O-O #portrait:Parlament #speaker:Andreea #layout:item
But the name Castle is actually pretty fitting cus its made with like tons of crystals and gold and precious materials... >:D #portrait:Castle #speaker:Andreea #layout:item
All sourced from Romania btw. ;) #portrait:Castle #speaker:Andreea #layout:item
Haha :D #portrait:Castle #speaker:Andreea #layout:item
yeah :D #portrait:Castle #speaker:Andreea #layout:item
So many people died during the construction of that place :') #portrait:Castle #speaker:Andreea #layout:item
+[That's insane]
Yeah... :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
yeah...... :') #portrait:Andreea_Happy #speaker:Andreea #layout:right
->why_are_you_here
->DONE
+[Meh I've heard worse]
Oh wow, ok mister smarty pants :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
No more castle stories for you then :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
Just kidding ;) #portrait:Andreea_Happy #speaker:Andreea #layout:right
I'll tell you as many castle stories as you want :* #portrait:Andreea_Happy #speaker:Andreea #layout:right
->why_are_you_here
->END

===why_are_you_here===
You curious about anything else? :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
+[Why are you here?]
In this kitchen or in Austria in general? ;) #portrait:Andreea_Happy #speaker:Andreea #layout:right
haha just kidding XD #portrait:Andreea_Happy #speaker:Andreea #layout:right
Well, as much as I love romanian culture <3 #portrait:Andreea_Happy #speaker:Andreea #layout:right
sadly, our country and it's government aren't in the best state currently :')  #portrait:Andreea_Happy #speaker:Andreea #layout:right
I am also not sure if it's ever been in it's best state actually haha XD #portrait:Andreea_Happy #speaker:Andreea #layout:right
But the wages keep stagnanting and well , the prices have just been rising since we joined the EU :') #portrait:Andreea_Happy #speaker:Andreea #layout:right
And I have a family, like anybody else :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
And I don't want to risk my family being in a situation where we can't afford groceries :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
So, I hope this answers your question :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
Anyway, thank you for your help again ! :* #portrait:Andreea_Happy #speaker:Andreea #layout:right
For some reason I just feel like you already work here XD #portrait:Andreea_Happy #speaker:Andreea #layout:right
Also, remember when i told you about the Spotlight festival ? Check out these news from Romania ! :D 
~spotlightVideo()
Collect your pay at the tezga :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
->DONE
+[Does Romania have electricity?]
WHY DO PEOPLE HERE KEEP ASKING ME THAAATTT??? o-O #portrait:Andreea_Happy #speaker:Andreea #layout:right
Sorry for shouting :)  #portrait:Andreea_Happy #speaker:Andreea #layout:right
I just have no clue where you guys get that idea from :/ #portrait:Andreea_Happy #speaker:Andreea #layout:right
Haha yes, silly :* #portrait:Andreea_Happy #speaker:Andreea #layout:right
We have electricity XD #portrait:Andreea_Happy #speaker:Andreea #layout:right
And even internet!! :O #portrait:Andreea_Happy #speaker:Andreea #layout:right
May I add, the fastest one in Europe! :) #portrait:Andreea_Happy #speaker:Andreea #layout:right
Anyway, thank you for your help again ! :* #portrait:Andreea_Happy #speaker:Andreea #layout:right
Also, remember when i told you about the Spotlight festival ? Check out these news from Romania ! :D 
~spotlightVideo()
For some reason I just feel like you already work here XD #portrait:Andreea_Happy #speaker:Andreea #layout:right
Collect Your pay at the tezga :D #portrait:Andreea_Happy #speaker:Andreea #layout:right
->END