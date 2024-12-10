INCLUDE globals.ink
VAR EPISODE_ONE_FINISHED_KAYAKING_GAME = "false"
VAR EPISODE_TWO_FINISHED_KAYAKING_GAME = "false"
VAR EPISODE_TWO_RHYTHM_GAME_FINISHED = "false"
VAR EPISODE_TWO = "false"
VAR HAS_SLINGSHOT = "false"
EXTERNAL startEpisodeOneKayakingGame()
EXTERNAL takeSlingshot()
EXTERNAL giveGun()

{ EPISODE_TWO == "false" : {EPISODE_ONE_FINISHED_KAYAKING_GAME == "false": -> main | -> already_played} | { EPISODE_TWO_FINISHED_KAYAKING_GAME == "false" : {HAS_SLINGSHOT=="false" : -> pre_slingshot | ->second_main} | ->second_already_played } }

=== main ===
Huh, you want the Wifi password?  #portrait:Fatima_Happy #speaker:Fatima #layout:right
Huh, you want the Wifi password?  #portrait:Fatima_Happy #speaker:Fatima #layout:right
Sur3 thing dud3...3xc3pt I can't both3r to r3m3mb3r right now... #portrait:Fatima_Happy #speaker:Fatima #layout:left
I'm trying to sort my album photos of my Kayaking Trip in Bosnia right now and can't r3m3mb3r which city is which...hmmm.... #portrait:Bosnia_Happy #speaker:Fatima #layout:left
Mayb3 you can h3lp me r3m3mb3r and then I h3lp you with the password? #portrait:Bosnia_Happy #speaker:Fatima #layout:left
-Whatcha say? #portrait:Bosnia_Happy #speaker:Fatima #layout:left
+ [Do I have a choic3?]
    Nop3 h3h3 <3 #portrait:Bosnia_Happy #speaker:Fatima #layout:left
+ [Sure]
    <color=\#5B81FF>AW3SOM3SAUC3!11!!</color>. #portrait:Bosnia_Happy #speaker:Fatima #layout:left


-Noowww l3t's g3t it start3d #portrait:Bosnia_Happy #speaker:Fatima #layout:left
~startEpisodeOneKayakingGame()
    
    -> END
    
=== second_main ===
Huh, you want the Wifi password?  #portrait:Fatima_Happy #speaker:Fatima #layout:right
OMMMIIGGOOOODDD !!11!!! U FOUND IT!!!! <3 <3 <3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
~takeSlingshot()
Omg, i totally forgot i left it at Zlatans place wh3n I was showing Goran how it works l3l. #portrait:Fatima_Happy #speaker:Fatima #layout:right
H3r3 as a thank you, I'll giv3 you on3 of my r3s3arch obj3cts...
~giveGun()
ITSSS A LAS33RRR GUUNNN ^_^ #portrait:Fatima_Happy #speaker:Fatima #layout:right
-h3h3h3h3h3h3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
+ [What do you even study?]
    Ah, I am doing two studi3s 
    Informatics and Physics at the TU
    And as part of my r3s3arch, I mad3 this 
    AND NOW YOU G3T ON3 TOOO
    Don't th3y ar3 compl3t3ly harml3ss
    You can't g3n3rat3 such a strong las3r with such a small d3vic3
    Yup
    Harml3ss
    Almosy compl3t3ly <3 <3
    just don't point it at your 3y3s pls <3
+ [Wtf? Why would I need this?]
    It's basically an acc3ssory l3l
    And as part of my r3s3arch, I mad3 this 
    AND NOW YOU G3T ONE TOOO
    Don't th3y are compl3t3ly harml3ss
    You can't g3n3rate such a strong las3r with such a small d3vic3
    Yup
    Harml3ss
    Almosy compl3t3ly <3 <3
    just don't point it at your 3y3s pls <3
But since you ar3 h3r3...  #portrait:Fatima_Happy #speaker:Fatima #layout:right
H3lp m3 sort th3 PCITUREEESS FROM MY KAYAKING TRIP
I found the actual on3s this tim3
I sw3ar!!111!
~startEpisodeOneKayakingGame()
h3h3  #portrait:Fatima_Happy #speaker:Fatima #layout:right
    ->END
    
===  pre_slingshot ===
Huh, you want the Wifi password?  #portrait:Fatima_Happy #speaker:Fatima #layout:right
Hey dude, I just came back from the t3chnical Univ3rsity in Saraj3vo.
-Do you know where my Slighshot could be?  #portrait:Fatima_Happy #speaker:Fatima #layout:right
+[Don't you study here in Vienna?] 
L3l y3ah. #portrait:Fatima_Happy #speaker:Fatima #layout:right
But w3've coll3borat3d for my Mast3rs study with our T3chnical Uni in Saraj3vo! #portrait:Elektrotehnicki #speaker:Fatima #layout:item
Which was aw3som3 for m3, cus I could visit that plac3 again. #portrait:Elektrotehnicki #speaker:Fatima #layout:item
the Univ3rsity th3r3 is actually pr3tty good.  #portrait:Elektrotehnicki #speaker:Fatima #layout:item
My sist3r just liv3s h3r3, so I kinda did as w3ll! ##portrait:Elektrotehnicki #speaker:Fatima #layout:item
Anyway, if you find it, pl3ase bring it to m3 :3 <3 <3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
->DONE
+[Slingshot?]
Y3ah my slingshot! #portrait:Fatima_Happy #speaker:Fatima #layout:right
I mad3 it so I could approximat3 the sp33d of small proj3ctil3s.  #portrait:Fatima_Happy #speaker:Fatima #layout:right
But in th3 3nd I didn't r3ally n33d it l3l. #portrait:Fatima_Happy #speaker:Fatima #layout:right
Anyway, if you find it, pl3ase bring it to m3 :3 <3 <3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
    ->END
    
=== second_already_played ===
Thank you SOOOOO MUCH DUUD333!!  #portrait:Fatima_Happy #speaker:Fatima #layout:right
Thank you SOOOOO MUCH DUUD333!!  #portrait:Fatima_Happy #speaker:Fatima #layout:right
I r3m3mb3r 3V3RYTHING now!  #portrait:Fatima_Happy #speaker:Fatima #layout:right
Th3 probl3m was that it was actually two diff3r3nt Kayking Trips and and thats why I was confus3d  #portrait:Fatima_Happy #speaker:Fatima #layout:right
This pictur3 I took at th3 Una R3gata!  #portrait:UnaRegata #speaker:Fatima #layout:item
Which is a big thing at my hom3town Bihac wh3r3 w3 have this ub3r cool vi3w!  #portrait:Bihac #speaker:Fatima #layout:item
I us3d to draw this all th3 tim3 as a kid! Lol, cring3  #portrait:Bihac #speaker:Fatima #layout:item
And th3 s3cond one was at the N3r3tva r3gata which is at this town call3d Mostar!  #portrait:Mostar #speaker:Fatima #layout:item
It has this Bridg3 with only on3 arch, which is sup3r int3r3sting actually becaus3 it shouldnt be physically possibl3 to stand lik3 this b3caus3 it is too long to only hav3 one arch  #portrait:Mostar #speaker:Fatima #layout:item
Back 500 y3ars ago, the best archit3ct in th3 t3ritory of Bosnia was task3d with cr3ating this  #portrait:Mostar #speaker:Fatima #layout:item
And the Sultan told him that h3'll lose his h3ad if the bridg3 collaps3d but the r3quir3m3nt was that it n33d3d to hav3 only one arch  #portrait:Mostar #speaker:Fatima #layout:item
So on th3 day that th3 construction was finish3d, th3 archit3ct just disapp3ar3d  #portrait:Mostar #speaker:Fatima #layout:item
Cus even h3 thought that it was going to collaps3 for sure  #portrait:Fatima_Happy #speaker:Fatima #layout:right
And th3r3 it is, still today, standing secur3ly ov3r N3r3tva  #portrait:Fatima_Happy #speaker:Fatima #layout:right
Today there is the tradition of jumping from the bridge during summer  #portrait:Skakaci #speaker:Fatima #layout:item
It looks so cool wh3n th3 div3rs do it!  #portrait:Skakaci #speaker:Fatima #layout:item
i p3rsonally would los3 a l3g  #portrait:Skakaci #speaker:Fatima #layout:item
L3L  #portrait:Skakaci #speaker:Fatima #layout:item
-Do you hav3 anything 3ls3 u'd lik3 to know mayhaps :3 ?!?!  #portrait:Fatima_Happy #speaker:Fatima #layout:right
    +[I didn't know muslim women were allowed to go to school]
    Oh boy  #portrait:Fatima_Happy #speaker:Fatima #layout:right
    If I had a c3nt 3v3rytim3 I was ask3d that qu3stion  #portrait:Fatima_Happy #speaker:Fatima #layout:right
    I'd hav3 lik3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
    A lot of ce3nts #portrait:Fatima_Happy #speaker:Fatima #layout:right
    Nowh3r3 in the r3ligion are wom3n prohibit3d from g3tting 3ducat3d r3ally #portrait:Fatima_Happy #speaker:Fatima #layout:right 
    And it's not r3ally about th3 r3ligion in th3 first plac3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
    It's hon3stly mor3 about the cultur3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
    In Bosnia you can or you don't hav3 to w3ar a Hijab 3ither  #portrait:Fatima_Happy #speaker:Fatima #layout:right
    So a lot of wom3n I know do w3ar it, but a lot don't  #portrait:Fatima_Happy #speaker:Fatima #layout:right
    It's r3ally up to what you want at the 3nd of th3 day  #portrait:Fatima_Happy #speaker:Fatima #layout:right
    I m3an, as you can t3ll from how i look obviously lol #portrait:Fatima_Happy #speaker:Fatima #layout:right
    And wh3r3 I com3 from it's actually also r3ally 3ncourag3d to g3t 3ducation!!! #portrait:Fatima_Happy #speaker:Fatima #layout:right
    Just lik3 in th3 r3st of 3urope! #portrait:Fatima_Happy #speaker:Fatima #layout:right
    And my fri3nds from Turk3y ar3 also usually highly 3ducat3d #portrait:Fatima_Happy #speaker:Fatima #layout:right
    My sister is lik3 10 y3ars old3r than m3 and has a Phd lol #portrait:Fatima_Happy #speaker:Fatima #layout:right
    Yeah I"ll always b3 in h3r shadow lol :') #portrait:Fatima_Happy #speaker:Fatima #layout:right
    Sh3s got like two kids on top of it all, crazy buzzin3ss imo, idk how sh3 do3s it #portrait:Fatima_Happy #speaker:Fatima #layout:right
    So idk dud3, I don't think its a r3ligious thing, It mor3 of a #portrait:Fatima_Happy #speaker:Fatima #layout:right 
    "Whats custom3ry in that plac3" thing I think #portrait:Fatima_Happy #speaker:Fatima #layout:right
    +[I thought Bosnia was still at war]
    Lmao no, I h3ar that all th3 tim3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
    Or that th3r3 is nothing th3r3 but grav3l #portrait:Fatima_Happy #speaker:Fatima #layout:right
    W3'r3 actually kind of trying to mov3 on from what happ3n3d 30 y3ars ago as you can imagin3 #portrait:Fatima_Happy #speaker:Fatima #layout:right
    It's just a bit hard, you could say #portrait:Fatima_Happy #speaker:Fatima #layout:right 
    W3 don't 3xsactly hav3 th3 most stabl3 gov3rnm3nt still #portrait:Fatima_Happy #speaker:Fatima #layout:right 
    Th3 p3opl3 are R3333ALLYY TRYYINGGG THOOOO #portrait:Fatima_Happy #speaker:Fatima #layout:right
    But still the only thing I 3v3r s33 on m3dia about us h3r3 is about y3t anoth3r catastrophy... #portrait:Fatima_Happy #speaker:Fatima #layout:right
    Sadly... #portrait:Fatima_Happy #speaker:Fatima #layout:right
    So I can't r3ally blam3 you for asking. #portrait:Fatima_Happy #speaker:Fatima #layout:right
Btw giv3 me your phon3, I'll subscrib3 you to this bosnian n3ws pag3, so you can g3t actual cool stuff thats happ3ning down th3r3!
w333ll, c ya th3n  #portrait:Fatima_Happy #speaker:Fatima #layout:right
k33p th3 toy :)  #portrait:Fatima_Happy #speaker:Fatima #layout:right
 ->END

=== already_played ===
Thanks for the help dud3!#portrait:Fatima_Happy #speaker:Fatima #layout:right
Thanks for the h3lp dud3!#portrait:Fatima_Happy #speaker:Fatima #layout:left
R3ally cool of you!#portrait:Fatima_Happy #speaker:Fatima #layout:left
I just r3m3mb3r3d that it wasn't my Kayaking Trip at all, but pictur3s from wh3n i w3nt to visit th3 Bosnian Pyramids #portrait:Fatima_Happy #speaker:Fatima #layout:left
-I totally forgot l3l
+ [Bosnia has pyramids?]
    Oh well...kinda? #portrait:Bosnia_Happy #speaker:Fatima #layout:left
+ [There's no way Bosnia has pyramids]
    WE TOT33SS DO THOOOO!!11! #portrait:Bosnia_Happy #speaker:Fatima #layout:left

-This is what they look like #portrait:Pyramids #speaker:Fatima #layout:item
On3 could argu3 that thos3 ar3 just som3 w3irdly shap3d mountains... #portrait:Pyramids #speaker:Fatima #layout:item
BUT I for on3 b3li3v3 in th3 dr3am! #portrait:Pyramids #speaker:Fatima #layout:item
Th3y ar3 in this plac3 call3d Visoko, which is kinda r3ally clos3 to Saraj3vo #portrait:Pyramids #speaker:Fatima #layout:item
Talking about Saraj3vo, I also dropp3d by th3r3 on my way back #portrait:Bascarsija #speaker:Fatima #layout:item
I took this on the Bascarsija, which is just kinda a cool nam3 for the c3nt3r of the city #portrait:Bascarsija #speaker:Fatima #layout:item
Oh y3 btw, I am from Bosnia , if you didn't alr3ady figur3 it out#portrait:Fatima_Happy #speaker:Fatima #layout:left
And Saraj3vo is our capital, which is basically the cool3st part of Bosnia #portrait:Fatima_Happy #speaker:Fatima #layout:left
I don't wanna bor3 you now with this stuff tho l3l #portrait:Bascarsija #speaker:Fatima #layout:item
Anyway, th3nks for your h3lp #portrait:Fatima_Happy #speaker:Fatima #layout:left
R3ally cool of you!#portrait:Fatima_Happy #speaker:Fatima #layout:left
...#portrait:Fatima_Happy #speaker:Fatima #layout:left
..#portrait:Fatima_Happy #speaker:Fatima #layout:left
What?#portrait:Fatima_Happy #speaker:Fatima #layout:left
Oh Y333AAHHH THE PASSSWOOORDDD#portrait:Fatima_Happy #speaker:Fatima #layout:left
Oh it's "TotallyNotAPassword123"#portrait:Fatima_Happy #speaker:Fatima #layout:left
Lel#portrait:Fatima_Happy #speaker:Fatima #layout:left

    -> END