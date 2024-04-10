# Minefield

The Objective of the game is to reach from left to right or top to bottom with 3 lives. 

The objective of the exercise is to demonstrate good clean code, logic, and to ensure SOLID principles are achieved.

#SOLID and Unit Testing

##Single Responsibility Principle (SRP)
The Game class has a single responsibility, which is to manage the game state and logic.The RandomProvider class has a single responsibility of providing random numbers.The Mine class represents a single mine entity.

##Open/Closed Principle (OCP)
The Game class is open for extension (e.g., adding new features such as different board sizes or game modes) but closed for modification.The addition of the IUserInterface interface allows for different implementations of user interaction without modifying the Game class.

##Liskov Substitution Principle (LSP)
The code doesn't directly involve inheritance, but it adheres to LSP by ensuring that derived classes can be substituted for their base classes without affecting the behavior of the program.

##Interface Segregation Principle (ISP)
The IUserInterface interface follows ISP by providing specific methods for user input and output operations, which can be implemented independently by different classes.

##Dependency Injection (DI)
Dependency injection is used to inject dependencies such as IRandomProvider and IUserInterface into the Game class, allowing for easier testing and decoupling from specific implementations.The RandomProvider class implements the IRandomProvider interface, and a concrete implementation of IUserInterface (e.g., ConsoleInterface) can be provided to the Game class.

##Separation of Concerns (SoC)
The code separates concerns by having distinct classes for game logic (Game), random number generation (RandomProvider), user interface (IUserInterface), and mine representation (Mine).Encapsulation:The internal state of the Game class is encapsulated, and its behavior is controlled through public methods (Play, PlayerHitMine, etc.), which adhere to the principle of encapsulation.

Overall, the provided code demonstrates good adherence to SOLID principles, dependency injection, and other best practices, making it modular, testable, and maintainable.

Time taken 42 minutes.

Sorry for only a handful of Unit Tests!
