# DIP

## Definition

Entities must depend on abstractions not on concretions. It states that the high
level module must not depend on the low level module, but they should depend
on abstractions.

## Violation Example

Let's have a look at the following class design.

```
   ___________                      ___________
  | Package A |                    | Package B |
  |———————————————————————.        |————————————————————.
  |                       |        |                    |
  |   ,---------------.   |        |   ,------------.   |
  |   |Notification   |   |        |   |Email       |   |
  |   |---------------|---|--------|-->|------------|   |
  |   |+Send()        |   |        |   |+SendMail() |   |
  |   `---------------'   |        |   `------------'   |
  `———————————————————————´        `————————————————————´


```

In this example we use a `Notification` class to send an email. 
The method `Send()` of the `Notification` class invokes the
`Send()` method of the `Email` class. Therefore we have a dependency of
`Package A` to `Package B`.

In this example the `Package A` is a high level module, because it does not concern
how the notification will be send, if by email or an other way. But
because we need the `Email` class we have a fix dependency from
`Package A` to `Package B`. But what we want is quite the opposite of the current
relation. We want the `Package B` to be dependable on `Package A`.

How can we solve this issue?

## Possible Solution

A possible solution would be to introduce an interface `IMessage` and place
it in `Package A`. The classe `Email` will implement this new interface and the
`Notification` does not need to depend on the concrete implementations of `Email`
anymore and thereby on the lower level `Package B`. Thus we have *inversed* the
dependency relation from `Package A` -> `Package B` to `Package B` -> `Package A`.

```

   ___________                        ___________
  | Package A |                      | Package B |
  |—————————————————————————.        |————————————————————.
  |                         |        |                    |
  |   ,--------------- .    |        |                    |
  |   |<< interface >> |    |        |   ,------------.   |
  |   |IMessage        |<|--|--------|---|Email       |   |
  |   |----------------|    |        |   `------------'   |
  |   |+Send()         |    |        |                    |
  |   `----------------'    |        |                    |
  |           ^             |        |                    |
  |           |             |        |                    |
  |   ,---------------.     |        |                    |
  |   |Notification   |     |        |                    |
  |   |---------------|     |        |                    |
  |   |+Send()        |     |        |                    |
  |   `---------------'     |        |                    |
  `—————————————————————————´        `————————————————————´

```