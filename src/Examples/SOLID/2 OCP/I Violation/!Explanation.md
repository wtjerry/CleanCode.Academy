# OCP

## Definition

Objects or entities should be open for extension, but closed for modification.

## Violation Example

Back to our example of the `AreaCalculator` class.

```

 ,---------------------------------.  
 |AreCalculator                    |  
 |---------------------------------|  
 |+AreCalculator(shapes : object[])|  
 |+Sum()                           |  
 `---------------------------------'  
         |                 |          
         v                 v          
,----------------.  ,----------------.
|Circle          |  |Square          |
|----------------|  |----------------|
|+Radius : double|  |+Length : double|
`----------------'  `----------------'

```

Now we add a third shape "equilateral triangle" to our structure. Because of this 
new shape we need to add another class `EquilateralTrinale` AND make some changes
in the `Sum()` method of the class `AreCalculator`.


```

 ,---------------------------------.  
 |AreCalculator                    |  
 |---------------------------------|  
 |+AreCalculator(shapes : object[])|  
 |+Sum()                           |-----------.
 `---------------------------------'           |
         |                 |                   |          
         v                 v                   v          
,----------------.  ,----------------.  ,--------------------.
|Circle          |  |Square          |  |EquilateralTriangle |
|----------------|  |----------------|  |--------------------|
|+Radius : double|  |+Length : double|  |+Length : double    |
`----------------'  `----------------'  `--------------------'

```

Is there a better way to solve this issue?