# OCP

## Definition

Objects or entities should be open for extension, but closed for modification.

## Violation Example

Back to our example of the `AreaCalculator` class.

```

 ,----------------------------------.  
 |AreaCalculator                    |  
 |----------------------------------|  
 |+AreaCalculator(shapes : object[])|  
 |+Sum() : double                   |  
 `----------------------------------'  
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
in the `Sum()` method of the class `AreaCalculator`.


```

 ,----------------------------------.  
 |AreaCalculator                    |  
 |----------------------------------|  
 |+AreaCalculator(shapes : object[])|  
 |+Sum() : double                   |----------.
 `----------------------------------'           `
         |                 |                    |          
         v                 v                    v          
,----------------.  ,----------------.  ,--------------------.
|Circle          |  |Square          |  |EquilateralTriangle |
|----------------|  |----------------|  |--------------------|
|+Radius : double|  |+Length : double|  |+Length : double    |
`----------------'  `----------------'  `--------------------'

```

Is there a better way to solve this issue?

## Possible Solution

Another issue we did not mentioned is that the class `AreaCalculator` accepts
any objects! In order for the `AreaCalculator` to be more stable we can
introduce a marker interface `IShape` which allows us to restric the range of
possible parameter values and prevent other issues.

```

 ,----------------------------------.                         ,-----------------.
 |AreaCalculator                    |------------------------>| << interface >> |
 |----------------------------------|                         | IShape          |
 |+AreaCalculator(shapes : IShape[])|                         `-----------------'
 |+Sum() : double                   |------------.                     A
 `----------------------------------'             `                    |
         |                  |                     |                    |
         |                  |                     |                    |
         v                  v                     v                    |
,----------------.  ,----------------.  ,--------------------.         |
|Circle          |  |Square          |  |EquilateralTriangle |         |
|----------------|  |----------------|  |--------------------|         |
|+Radius : double|  |+Length : double|  |+Length : double    |         |
`----------------'  `----------------'  `--------------------'         |
         |                  |                     |                    |
          `-----------------------------------------------------------´

```

But this approach does not yet solve the issue that we have to make changes
to the `AreaCalculator` for new shapes. As a possible solution we can further
extend the `IShape` interface with a specific `GetArea()` method and move the
logic of calculating the different shape areas into the specific shape classes.
The class `AreaCalculator` will then only be in charge of summing up all the
individual shape areas.

```

 ,----------------------------------.                          ,-------------------.
 |AreaCalculator                    |------------------------->| << interface >>   |
 |----------------------------------|                          | IShape            |
 |+AreaCalculator(shapes : IShape[])|                          |-------------------|
 |+Sum() : double                   |                          |+GetArea() : double|
 `----------------------------------'                          `-------------------'
                                                                       A
                                                                       |
         -------------------------------------------------------------´
         |                  |                     |
,----------------.  ,----------------.  ,--------------------.
|Circle          |  |Square          |  |EquilateralTriangle |
|----------------|  |----------------|  |--------------------|
|-radius : double|  |-length : double|  |-length : double    |
`----------------'  `----------------'  `--------------------'

```

With this appreach we do not need to touch the `AreaCalculator` class anymore
if we add additional shapes. Further the `AreaCalculator` even does not need to
depend on any concrete implementations of the `IShape` interface. We can even hide the 
properties of the shape classes because there are not needed by the 
`AreaCalculator` class anymore and further loosen some dependencies.
