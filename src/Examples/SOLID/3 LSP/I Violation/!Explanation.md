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

                    /\
                   /   \
               A  /      \  B
                 /         \
                -------------
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