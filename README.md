# CarSimulatorApp
## 📃Description
This is a simple car simulator application written in C# console. The app gives the user options to drive a car towards different cardinal directions, while simultaneously 
managing the vehicles gas meter and the drivers energy value which deteriorates every time an action is performed. If any of these values hit zero the user will be adviced to either stop and gas or take a rest.  
The main purpose of this application is to demonstrate well structured C# code in regards to SRP (Single Responsibility Principle), and to implement valid tests of the simulations functionality. The written tests makes sure that the key 
components of the applications logic is solid and that no runtime bugs or logical errors occurs. The application also consumes an external API called "Random User API", which imports a fictional user that the application uses as its driver.
The driver will be replaced by a new driver each time the application re-starts.

## :computer: Usage
To drive the car, select any of the directional options available in the menu. The cardinal direction is always determined by the car's current movement. For example, if the car is moving north, reversing the car will change the direction to south. After each action, both the car's status and the driver's status will be decreased. The user will receive notifications about the changing values through an active meter and current status messages.
By design, the car will continue moving even after the status values have reached zero.  



## 🛠️ Implementations
CarSimulatorApp was created in C#. The solution contains six different projects, some responsible for the application's logic and services, and others for testing purposes. 
The main project, CarSimulator, is a C# console application responsible for the startup and runtime of the solution. Furthermore, the solution utilizes three class libraries called 'DataLogicLibrary,' 'ValidationServiceLibrary,' and 'APIServiceLibrary.'
The DataLogicLibrary is responsible for the simulation logic and uses various services to manage the flow and development of logic during runtime.
The ValidationServiceLibrary contains a ValidationService that ensures no incorrect input is allowed from the user. The APIServiceLibrary contains a service that consumes the external randomuserapi and returns a response DTO to the main project.

'DataLogicLibraryTests'is an MSTest project that includes all of the SimulationLogic tests. Its corresponding tests verify the functionality of the driving logic and the changing status values.
It also contains MOQ tests responsible for testing hunger values. This functionality has not yet been implemented in the application but is simulated with the help of MOQ. This way, it is possible to test the feature even though its logic has not yet been implemented in the application.

'ValidationServiceTests' is an NUnit test project that includes all of the ValidationService tests. It verifies that the functionality of the validation user input method works as intended and that the correct menu option number is returned to the main project.

'APIServiceTests' is an MSTest test project that includes an integration test for the APIService. The purpose of this test is to make sure that the api service returns a random user with valid properties that can be converted in to a driver later used by the application.

CarSimulatorApp is designed with SRP and clean code in mind, meaning that it implements OOP (Object Oriented Programming) and design patterns to avoid concretions and promote maintainable code structure.
An example of this is the implementation of strategy pattern for the direction logic which allows the CarSimulatorApp to dynamically change its behavior based on different direction options selected by the user. To avoid concretions, the application also relies on factory pattern to retrieve the neccessary classes used in the simulations runtime logic. All patterns and dependencies are managed through the use of dependency injection and interfaces ensuring loose coupling.
