# C# & .Net

## Compiled V.S. Interpreted language

- Compiled language 編譯語言:
    - Low-level programming language
    - Sorce code -> Compiled language -> Machine Code
    - Execution: faster and more efficient
    - Debug: slower
    - EX: C, C++, Go

- Interpreted language 直譯語言:
    - Interpreter run through **line by line** and execute
    - Execution: slower
    - Debug: faster
    - EX: PHP, Python, JavaScript

- Just-in-time Compilation (JIT) 即時編譯:
    - Improving the performance of interpreted programs
    - Dynamic compilation 動態編譯
    - JIT determines the most frequently used code and compiles it to machine code
    - EX: Java (JVM), C# (CLR)

## Dependency Injection - Lifetime

- AddTransient():
    - instance is light, easy to create

- AddScoped():
    - reuse instance is an request thru different class

- AddSingleton():
    - not cheap to instanciate
    - keep track of the state throughout the whole application

## Anonymous Type 匿名類型

- A set of **read-only** properties into a single object
- Not having to explicitly define a **type** first
- ex: var v = new { p1 = 1, p2 = "text" };  
&nbsp; &nbsp; &nbsp; Console.WriteLine(v.p1 + v.p2);

## Extension Methods
- **Add** methods to existing types without modifying the original type
- static method
- **Lower** priority: Unable to override methods of a classs or interface (Compiler decision)