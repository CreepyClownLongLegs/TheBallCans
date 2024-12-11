VAR EPISODE_TWO_FINISHED_RHYTHM_GAME = "false"
VAR EPISODE_ONE_FINISHED_RHYTHM_GAME = "false"
VAR EPISODE_TWO = "false"
VAR HAS_SLINGSHOT = "false"
EXTERNAL pljeskavicaVideo()
EXTERNAL giveSlingshot()
EXTERNAL startRhytmGame()

{EPISODE_TWO == "false" : {EPISODE_ONE_FINISHED_RHYTHM_GAME == "false" : -> main | -> game_one_played} | {EPISODE_TWO_FINISHED_RHYTHM_GAME == "false" : -> main_two | {HAS_SLINGSHOT == "false" : -> game_two_played | -> gotten_slingshot}}}

=== main ===
<b>That what you did for Andreea...</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>Oh no...</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>My dads watching that stupid show again.</b>
<b>It's a show where contestants from the Balkans come to sing, as you might have guessed from the noise.</b>
<b>It's called Zvezde Granda.</b>
<b>You could say it's like a blend of The Idol and The Voice, if you know those shows?</b>
<b>The contestants can win crazy prizes, among the normal ones like an album production, song or music video, some seasons even gave the winners a car or an apartment in Belgrade.</b>
<b>Very ludicrous, if you ask me.</b>
<b>... anyways...</b>
<b>Have I mentioned that the show started in Belgrade?</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>Have you heard of Belgrade? Do they mention the city in your history books?</b>
+[Not really.]
    <b>Well it's the capital of Serbia and also the biggest city with about 1.2 million citizens living in it.</b>#speaker:Zlatan #portrait:Belgrade #layout:item
    <b>It's located on the rivers Sava and Danube, which also flows through Vienna. A cool thing to share with yall!</b>
    <b>The Kalemegdan Fortress, located in the middle of Belgrade, has been there for around 2000 years!</b>#portrait:Kalemegdan #layout:item #speaker:Zlatan
    <b>That's a lot of years...</b>
    <b>It used to be the whole town, until Belgrade expanded.</b>
    <b>Now it's a cultural and festival center, which tourists and citizens can visit for free all year round.</b>
    <b>There's also this huge park called Kosutnjak Hill, where people go to recreate. On this 330 hectar park, there are lots of forests and trails to go on.</b> #portrait:Kosutnjak #layout:item #speaker:Zlatan
    <b>Very healthy, very relaxing.</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
    <b>It used to be a royal hunting reserve, but now it's used for sport and lots of filming.</b>
    ->start_game_one
+[Yeah, I've been there a couple of times.]
    <b>Oh wow. That's amazing! We don't really have many "first world" citizens visit our country lol.</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
    <b>Then I'm not gonna bore you with all of the facts, since you probably know a bunch.</b>
    ->start_game_one

=== start_game_one ===
...#speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>...</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>OH RIGHT! My old man!</b>
<b>Could you please help the singers sing well?</b>
~startRhytmGame()
<b>Thanks!</b> 
->END

=== game_one_played ===
Bruh.
<b>That guy can really sing, huh?</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:right
<b>He's from Nis. The cultural center of Serbia.</b>
<b>It houses veeeeery old archeological sites, such as Mediana, from the roman times.</b>#speaker:Zlatan #portrait:Mediana #layout:item
<b>Yeah, we were conquered by the Romans way back.</b>
<b>If you're into creepy and scary stuff, like my younger brother, then you'd love Cele Kula, aka the Skull Tower.</b>#portrait:Skulltower #speaker:Zlatan #layout:item
<b>It was built by the Ottomans after Serbian rebels detonated basically a bomb in their camp, in order to escape being impaled by the winning Ottomans.</b>
<b>Quite morbid to build that tower out of your enemies, if you ask me...</b>
<b>It was since been dismantled, but later restored with a chapel surrounding it.</b>
<b>...aaanyways, thanks for helping my old man, cya around, kiddo!</b>
<b>Hope you can sleep tonight with that tower imbedded into your brain haha...</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
->END

=== main_two ===
Bruh. #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>This one is going to be harder than the last one. My old man was very impressed by your last performance.</b> #speaker:Zlatan
<b>So I think you set his standards pretty high.</b> #speaker:Zlatan
<b>Can you work your magic once more?</b> #speaker:Zlatan
~startRhytmGame()
<b>You're a life saver.</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
->END
    
=== game_two_played ===
<b>That what you did for Andreea...</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>Wow, u really do done played that thing</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left

<b>That guy was from Novi Sad. The second biggest city in Serbia.</b>
<b>Fact time!</b>
<b>Since its founding, in 1694, it has (and still is) an important trading, manufacturing and cultural center.</b>#portrait:NoviSad #layout:item #speaker:Zlatan
<b>That's why it's been dubbed Serbian Athens.</b>
<b>It is also a university town, where lots of students come to study.</b>
<b>Here you can try one of the best pasulj, a typical bean stew with smoked meats like bacon and sausage.</b> #portrait:Pasulj #layout:item #speaker:Zlatan
<b>And kajmak, a creamy dairy food, usually served on the side, like ketchup.</b>#portrait:Kajmak #layout:item #speaker:Zlatan
<b>If you're more into drinking, there are a bunch of vineyards scattered across Novi Sad.</b>#portrait:VineyardsNS #layout:item #speaker:Zlatan
<b>...</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>By the way, let me show you something on your phone...</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
~pljeskavicaVideo()
<b>Since we are on the topic of foods, theres a video about the world's biggest pljeskavica!</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>Homemade in Leskovac. This year they made it 86,4kg!!! Insane right?</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>...</b>#speaker:Zlatan #portrait:Zlatan_happy #layout:left

<b>Oh yeah right, Bosnia gave me this, could you bring it back to her?</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
~giveSlingshot()
<b>Thanks man</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
    ->END
    
=== gotten_slingshot ===
<b>That what you did for Andreea...</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
<b>...You should probably get going dude...</b> #speaker:Zlatan #portrait:Zlatan_happy #layout:left
    ->END