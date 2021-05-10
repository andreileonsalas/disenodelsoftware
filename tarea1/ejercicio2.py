
class Observer:
    def __init__(self, name, subject):
        self.name = name
        subject.register(self)

    def notify(self, event):
        print(self.name, "notificacion: ", event)

        

class Client(Observer):
    
    def __init__(self, name, subject):
        self.name = name
        subject.register(self)
      
    def recibido(self):
        print("nueva promo")


class Subject:
    
    def __init__(self):
        self.Clients = []

        self.promoTime = 0
        self.discount = ""

        self.state = False


    def promoFlash(self):
        temp = input("Escriba el descuento a dar: ")
        self.discount = temp

    def flashTime(self):
        temp = input("Escriba el tiempo que durara: ")
        self.promoTime = temp
            
    def getPromo(self):
        return self.discount and self.promoTime
            
    def getState(self):
        return self.state

    def register(self, Client):
        self.Clients.append(Client)

    def unregister(self, Client):
        self.Clients.remove(Client)

    def notify_Client(self, event):
        for Client in self.Clients:
            Client.notify(event)

    def changeState(self):
        self.state = True
        self.notify_Client("Aproveche hay un descuento de: "+ self.discount + "% y acabara dentro de  " + self.promoTime + " minutos")
            

def main():
    subject = Subject()
    temp = Client("Cliente1", subject)
    temp = Client("Cliente2", subject)
    temp = Client("Cliente3", subject)
    temp = Client("Cliente4", subject)


    if subject.getState() == False:
        subject.flashTime()
        subject.promoFlash()
        subject.changeState()
        
    
if __name__ == "__main__":
    main()   
