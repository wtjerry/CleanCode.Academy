# LSP

## Definition

Let q(x) be a property provable about objects of x of type T. Then q(y) should be
provable for objects y of type S where S is a subtype of T.

## Violation Example

Another example with the `AreaCalculator` class with some modifications.

```

 ,---------------------------------------.
 |AreaCalculator                         |
 |---------------------------------------|
 |+AreaCalculator(triangles : Triangle[])|
 |+Sum()                                 |
 `---------------------------------------'
         |                 |           
         |                 v           
         |       ,--------------------.
         |       |Triangle            |
         |       |--------------------|
         |       |+LengthA : double   |
         |       |+LengthB : double   |
         |       |+LengthC : double   |
         |       |--------------------|
         |       |+GetArea() : double |
         |       `--------------------'
         |                 A           
         |                 |           
         |       ,--------------------.
          `----->|EquilateralTriangle |
                 |--------------------|
                 |+GetArea() : double |
                 `--------------------'


Note: A regular Triangle is defined by three sides A, B and C.

                    /`
                   /   `
               A  /      `  B
                 /         `
                -------------`
                     C
```

In this example only two shapes are used: `Triangle` and `EquilateralTriangle`.
Because we consider the equilateral triangle to be just some other form of a 
triangle, the class `EquilateralTriangle` derives from the class `Triangle`.

The class `AreaCalculator` calculates the sum of the areas of all kinds of
triangles.

At first sign there does not see anything suspicious. Let's have a look at the
following code.

```

Triangle triangle = new EquilateralTriangle();
triangle.LengthA = 2;
triangle.LengthB = 3;

```

We know that within the implementation of `EquilateralTriangle` all lengths
are set to the value provided. Different lengths are a violating the definition
of an equilateral triangle.

Therefore we can conclude that implementations of `EquilateralTriangle`
do not behave the same way as implementations of `Triangle`. This means that
this sample implementation violates the Liskov Substitution principle.

How can we solve this issue?

## Possible Solution

A possible solution is to introduce an abstract class `Shape` and define
the method `GetArea()` as abstract as well. The previous class `Triangle`
will be renamed to `RegularTriangle` to underlinde it's difference with
the `EquilateralTriangle` class. Instead of using three length properties
for the class `EquilateralTriangle` we can simplify this matter by using
only one `Length` property.

```

 ,---------------------------------------.
 |AreaCalculator                         |
 |---------------------------------------|
 |+AreaCalculator(shapes : Shape[])      |
 |+Sum()                                 |
 `---------------------------------------'
                    |
                    v
    ,---------------------------------.
    |<< abstract >>                   |
    |Shape                            |
    |---------------------------------|
    |<<abstract>> +GetArea() : double |
    `---------------------------------'
                    A
                    |
            -------´ `-------------
           /                       \
    ,--------------------.  ,--------------------.
    |EquilateralTriangle |  |RegularTriangle     |
    |--------------------|  |--------------------|
    |+Length : double    |  |+LengthA : double   |
    |--------------------|  |+LengthB : double   |
    |+GetArea() : double |  |+LengthC : double   |
    `--------------------'  |--------------------|
                            |+GetArea() : double |
                            `--------------------'

```

Now both implementations of the `Shape` class do not break the general
behaviour of the parent class. Therefore the Liskov Substitution Principle
is not violated any more.