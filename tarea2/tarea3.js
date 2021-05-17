var Aviones = function(name,posicion) {
    this.name = name;
    this.posicion = posicion;
    this.torreDeControl = null;
};

Aviones.prototype = {
    //message from planes
    send: function(message, to, posicion) {
        this.torreDeControl.send(message, this, to, posicion);
    },
    receive: function(message, from,posicion) {
        if (typeof from === 'undefined') {
            log.add( "Torre de control hacia " + this.name + ": " + message);
        }
        else
            log.add(from.name + " hacia Torre de control: hacia " + message);
    }
};

var TorreDeControl = function() {
    var avionesMonitoreados = {};
    //observer
    return {
        name: 'Torre de Control',
        register: function(avion) {
            avionesMonitoreados[avion.name] = avion;
            avion.torreDeControl = this;
        },
 
        send: function(message, from, posicion) {

                if (from.name.localeCompare('Torre de control') === 1) {
                    for (key in avionesMonitoreados) {   

                            
                            avionesMonitoreados[key].receive(message);

                    }
                } else {
                    for (key in avionesMonitoreados) {   
                        if (avionesMonitoreados[key] !== from) {
                            
                            
                        }else{
                            avionesMonitoreados[key].receive(message, from);
                            avionesMonitoreados[key].posicion = posicion;
                        }
                    }
                }

            
        }
    };
};
 
// log helper
 
var log = (function() {
    var log = "";
    
    return {
        add: function(msg) { log += msg + "\n"; },
        show: function() { console.log(log); log = ""; }
    }
})();
 
function run() {
    var avion01 = new Aviones("avion01",0);
    var avion02 = new Aviones("avion02",0);
    var avion03 = new Aviones("avion03",0);
    var avion04 = new Aviones("avion04",0);
 
    var torreDeControl = new TorreDeControl();
    torreDeControl.register(avion01);
    torreDeControl.register(avion02);
    torreDeControl.register(avion03);
    torreDeControl.register(avion04);
 
    avion01.send("Requiero la localizalizacion del avion 01");
    torreDeControl.send('Donde se encuentra avion01',torreDeControl);
    avion02.send("Esta es mi posicion: 4", 4);
    // avion03.send("Ha, I heard that!");
    // avion04.send("avion03, what do you think?", 1);
 
    log.show();
}


run()
//setInterval(run,10000);
