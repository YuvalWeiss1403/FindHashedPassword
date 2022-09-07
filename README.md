# FindHashedPassword
Finding a password (represented as a phone number) from a given md5 hash. Using a Master and Minion (slave) architecture.
Because the project can be resource - intensive, it should be able to run across several machines.
So for that we will have a master server that handels the input processing and manages several minion servers, in order for them to crack the hash in parallel.


The web application project, represent the minion (slave), who is a micro service docker,
that receives a hash of a passwors and a phone number code ("050" / "051"......).
The project is devided by controllers, and entities.
The controller is running the functions that goes over all the permutations of the remaining digits of the phone number,
encodes them in to MD5 encryption, and compers them to the given hash.


Master project should be a container, that is running all the micro services with a load balancer.
for now the master is a console application project, depending on the web application project,
creating a new micro service for each phone number code, by an index order until finding the correct number equles to the password hash.


How to Use?
Open the solution , and run the Master class.
Enter the hash,
you can use https://www.md5hashgenerator.com/ to create your hash.
and the program will print the phone number.
