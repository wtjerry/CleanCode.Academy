# ISP

## Definition

A client should never be forced to implement an interface that it doesn't use or
clients shouldn't be forced to depend on methods they do not use.

## Violation Example

Let's have a look at the following class design.

```

    ,---------------------------------.
    |<< interface >>                  |
    |IShape                           |
    |---------------------------------|
    |+GetArea() : double              |
    |+GetVolume() : double            |
    `---------------------------------'
                    A
                    |
             ------´ `--------
            /                 \
        ,-------.          ,------.
        |Square |          |Cube  |
        `-------'          `------'

```

The programmer in charge just introduced a method `GetVolume` into the `IShape`
interface in order to support 3D objects like cubes.

The issue with this design is that the class `Square` has to implement the
`GetVolume` method as well, even though a square shape has no volume because
it is flat.

How can we solve this issue?

## Possible Solution

A possible solution would be the introduction of an additional interface
`ISolidShape`. This interface requires the implementation of the method
`GetVolumne()` and is only implemented by solid shapes.

```

    ,----------------------.   ,----------------------.
    |<< interface >>       |   |<< interface >>       |
    |IShape                |   |ISolidShape           |
    |----------------------|   |----------------------|
    |+GetArea() : double   |   |+GetVolume() : double |
    `----------------------'   `----------------------'
            A        A                A
            |        |                |
            |        `---------------´
            |                |
        ,-------.        ,------.
        |Square |        |Cube  |
        `-------'        `------'

```

With this our issue can be solved.