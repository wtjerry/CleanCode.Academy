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
 |+Sum()                            |  
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