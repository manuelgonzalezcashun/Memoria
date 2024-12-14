VAR worldName = ""

Hello World
I also am from this World
Can you remind me what this world is called?
* [Earth]
~ worldName = "Earth"
-> chosen(worldName)

* [Bluey]
~ worldName = "Bluey"
-> chosen(worldName)

* [I don't know you] -> aggressive

=== chosen(name) === 
How Facinating.
Thank you for welcoming me to your planet {name}.
-> END

===aggressive===
You will rue the day!
-> END