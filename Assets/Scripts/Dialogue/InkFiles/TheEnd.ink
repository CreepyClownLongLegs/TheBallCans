EXTERNAL endGame() 
EXTERNAL isInContacts(charaName)

Good job kid! #speaker:Narrator
You really balkaned all over the place #speaker:Narrator
Lol #speaker:Narrator

~temp granpaHere = isInContacts("Grumpy (Zlatans Grandpa)")
~temp zlatanHere = isInContacts("Zlatan (Serbia)")
~temp josipHere = isInContacts("Josip (Crotia)")
~temp fatimaHere = isInContacts("Fatima (Bosnia)")
~temp grandmaHere = isInContacts("Andreeas Grandma")
~temp andreeaHere = isInContacts("Andreea (Romania)")
~temp georgiHere = isInContacts("Georgi (Bulgaria)")
~temp jelenaHere = isInContacts("Jelena (Herzegowina)")
~temp emineHere = isInContacts("Emine (Kosovo)")
~temp marijaHere = isInContacts("Marija (Slovenia)")
~temp goranHere = isInContacts ("Goran (Zlatans brother)")
~temp mimozaHere = isInContacts ("Mimoza (Albania)")


{
-granpaHere == "true":
    <i>Huh, who are you please, why  are you in my house</i> #speaker:Grandpa
}

{
-zlatanHere == "true":
   <b>Grandpa we're having a welcome party for the new kid</b> #speaker:Zlatan
}

{
-fatimaHere == "true":
    I was told to g3t th3 Lactos3 fr33 milk cus app3arently som3body is Lack To3s Intolitarian #speaker:Fatima
    what3v3r that m3ans, but that sound3d dumb, so I got th3 normal on3 l3l #speaker:Fatima
}

{
-grandmaHere == "true":
    Ah, finally a get-together. ( ^o^) #speaker: Andreeas Grandma
    I love mingling with the youth, makes me feel young again! ( ^ ^) #speaker: Andreeas Grandma
}

{
-andreeaHere == "true":
    Does everyone have food on their plate? #speaker: Andreea
    There's enough, so don't be shy. ;) #speaker: Andreea
}

{
-georgiHere == "true":
    This Is A Really Good Sausage, Zlatan! #speaker: Georgi
}

{
-jelenaHere == "true":
    Fatima, can you check if my makeup looks good? #speaker: Jelena
    I bought this new eyeliner, and just tried it out. #speaker: Jelena
}

{
-emineHere == "true":
    Do you want to try some of my cat shaped cookies? :3 #speaker:Emine
}

{
-mimozaHere == "true":
    Try this, they don't sell hard stuff like this in Austria. hehe~ #speaker: Mimoza
}

{
-marijaHere == "true":
    Are_those_sausages_vegan? #speaker: Marija
    Jeez! They_should_involve_more_non_meat_alternatives... #speaker: Marija
}

{
-goranHere == "true":
    Mannn whennn will thisss enddd..!! #speaker: Goran
    Iii gottt aaa gameee tooo playyy!!! #speaker: Goran
}

{
-josipHere == "true":
    Guys, I think somebody put lactose in my milk. Where is the toilet? #speaker:Josip
}

~endGame()
Good job

