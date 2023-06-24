# Metrics-for-snake-game
calculating code metrics for snake game

<strong>Calculating Cyclomatic Complexity:</strong>
Cyclomatic complexity is a software metric that measures the complexity of a program by counting the number of independent paths through its source code. It helps in identifying code that may be more difficult to understand, test, and maintain. The cyclomatic complexity of a program can be calculated using the following formula:

CC = E - N + 2P

Where:
CC is the cyclomatic complexity.
E is the number of edges in the control flow graph.
N is the number of nodes in the control flow graph.
P is the number of connected components (e.g., multiple entry/exit points).

<strong>To calculate maintainability</strong>, the most commonly used metric is the Maintainability Index (MI), which takes into account various factors such as cyclomatic complexity, lines of code, and comment density. The MI score ranges from 0 to 100, where a higher score indicates better maintainability.
The formula for calculating the Maintainability Index (MI) is:
MI = 171 - 5.2 * ln(Halstead Volume) - 0.23 * (Cyclomatic Complexity) - 16.2 * ln(Lines of Code)
Note: Halstead Volume is a measure of the program's complexity based on the number of unique operators and operands.

Calculating Inheritance Level:
The inheritance level refers to the depth or hierarchy of classes involved in inheritance relationships within a software system. It measures the number of ancestor classes that a given class has.

Calculating Coupling:
Coupling is a measure of how interconnected different components or modules of a software system are. It indicates the level of dependency between components and the potential impact of changes in one component on others.
To calculate coupling, you need to analyze the code and identify the dependencies between different modules or classes. This can include method invocations, variable references, and data sharing between components.

Metrics	Actual
Time taken (in minutes):	1
Cyclomatic complexity:	20
inheritance level:  0
maintainablity:  -
coupling:  -
Lines of Code:	135
Overcomplicated code (i.e. can be converted to ternary):	0
Dead code (i.e. unused variables):	0
Overall total errors:	0
