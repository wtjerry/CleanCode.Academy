# SRP

## Definition

A class should have one and only one reason to change, meaning that a class should have only one job.

## Violation Example

The following example uses a `AreaCalculator` to calculate the area of shapes.

```
 ,----------------------------------.  
 |AreaCalculator                    |  
 |----------------------------------|  
 |+AreaCalculator(shapes : object[])|  
 |+Sum() : double                   |  
 |+WriteToConsole()                 |  
 `----------------------------------'  
         |                 |          
         v                 v          
,----------------.  ,----------------.
|Circle          |  |Square          |
|----------------|  |----------------|
|+Radius : double|  |+Length : double|
`----------------'  `----------------'

```

The issue is that the AreaCalculator handles the logic to output
the data using the `WriteToConsole()` method as well as calculating
the sum of the areas using the `Sum()` method.

But what if we want to output the data as json or something else?

## Possible Solution

A possible solution is to create a new class `OutputFormatter`
which is in charge of formatting the output in the desigred format.

```
 ,---------------------------------------.  
 |OutputFormatter                        |  
 |---------------------------------------|  
 |+ToSimpleString(sum : double) : string |  
 |+ToJsonString(sum : double) : string   |  
 |+ToHtmlString(sum : double) : string   |  
 `---------------------------------------'

```

This enables us to add multiple formatted output possibility at one point
(within one class). Additionaly we are not restricted to the Console as
output medium any more, but are even enabled to write the formatted result
to a file or other destination.