
Use the following code on http://www.plantuml.com to generate an UML image.

```
@startuml
abstract class I as "Item" {
  + Id : int
  + Titel : string
  + PriceInChf : decimal
  + ChangeColor(color : ItemColor)
  + GetString() : string
  + GetPriceInEuro() : decimal
}
class P as "Pen"
class B as "Book" {
  + Author : string
  + GetString() : string
}
class NB as "Notebook"
enum IC as "ItemColor" {
  Red
  Blue
  Green
  Yellow
}
class Col as "ItemCollection" {
  - isInitialized : bool
  - ItemsAsJsonString : string
  - allItems: Item[]
  + Initialize()
  + GetAllItems() : Item[]
  + GetPen(color : ItemColor) : Pen
  + GetBook() : Book
  + GetNotebook(color : ItemColor) : Notebook
  - CheckInitialized()
  - DeserializeJson(jsong : string) : Item[]
}

note right of IC
  only Notebooks can be Yellow
end note

class S as "ShoppingBasket" {
  - itemsInBasket : Item[]
  + Add(item : Item)
  + PrintToConsole()
  + SendOrderMail(toAddress : string)
}

class SMTP as "SmtpClient" {
  + Send(mail : MailMessage)
}

P -up-|> I
B -up-|> I
NB -up-|> I

I -right-> IC : Color
Col -down-> I

S o-right-> I : itemsInBasekt
S -down-> SMTP : mailMessage >
@enduml
```