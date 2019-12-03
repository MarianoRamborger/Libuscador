
let sbtn = document.querySelector("#searchButton");
let sbox = document.querySelector("#searchBox")
let xhr = new XMLHttpRequest;
let filtrobtn = document.querySelectorAll(".dropdown-item")
let results = document.querySelector("#resultadosPanel")
let navlinks = document.querySelectorAll(".navLink")
let advBtn = document.querySelector("#advancedButton")
let advSearchButton = document.querySelector("#advSearchButton")
let advSection = document.querySelector("#advArea")
let advInput = document.querySelectorAll(".advInput")

let busqueda = {
    filtro: "../LIBROS/BuscarPorTitulo",
    querystring : "Titulo"
}


for (let i = 0; i < filtrobtn.length; i++) {

    filtrobtn[i].addEventListener("click", (e) => {
        busqueda.filtro = e.target.dataset.filtro
        busqueda.querystring = e.target.dataset.querystring
})
}




let  cleanAndPrep = (a) => {


    // Parsea el string para targetear los controllers.
    let split = a;
    let stringy = split.toString();
    let lowstring = stringy.toLowerCase();


    let searchThis = lowstring.split(' ').join('+');

    sbox.value = "";
   
    return (searchThis)
   

}



let spawnSpinner = (a) => { //Recibe elemento, le appendea spinner

    let newImg = document.createElement("img");
    newImg.src = "../Content/Images/spinner.gif";
    newImg.classList = "spinnerSize";
    a.appendChild(newImg);

    

}



sbtn.addEventListener("click", (e) => { //Controla el rendereo de los libros.




    let params = cleanAndPrep(sbox.value);

    results.classList.add("mostrar"); 
    
    spawnSpinner(results);



    xhr.open("GET", `../Libuscador/${busqueda.filtro}?${busqueda.querystring}=${params}`)

    
    xhr.addEventListener("readystatechange", () => {

       
  
   
        if (xhr.status === 200 && xhr.readyState === 4) {
          
            results.innerHTML = ""

            var resultadosfinales = JSON.parse(xhr.response)

          
            

            //Checkea si no encontró nada y responde.
            if (resultadosfinales === "Lo sentimos. No hemos encontrado resultados.") {
                let bookDisplay = document.createElement("div");
                bookDisplay.classList = `resultadoBusqueda`
                bookDisplay.innerHTML = "Tu busqueda está en otro castillo."
                results.appendChild(bookDisplay);
            }


            //Devuleve resultados.
            else {
                for (var i = 0; i < resultadosfinales.length; i++) {
                    for (var u = 0; u < resultadosfinales[i].length; u++) {


                        let bookDisplay = document.createElement("div");
                        let bookDisplayTxt = document.createElement("p");

                        bookDisplay.classList = `resultadoBusqueda`
                        bookDisplayTxt.classList = `resultadoTexto`

                        bookDisplayTxt.innerHTML = `Titulo: ${resultadosfinales[i][u].titulo}.   Autor: ${resultadosfinales[i][u].nombre}.   
                         ISBN: ${resultadosfinales[i][u].ISBN}. Editorial: ${resultadosfinales[i][u].Editorial}. Genero: ${resultadosfinales[i][u].Genero}
                           <a  href="/Editar/EditarLibro/${resultadosfinales[i][u].Id}"><i class="fas fa-pencil-alt resIcon"> </i></a>  
                            <a  href="/Eliminar/EliminarLibro/${resultadosfinales[i][u].Id}"><i class="fas fa-trash  killIcon resIcon "> </i></a>                                                                                                          `

                        

                        bookDisplay.appendChild(bookDisplayTxt);


                        results.appendChild(bookDisplay);


                      


                       




                    }
                 
                }
                selfDestruct();
                }


          

 

        }
    })
  
    xhr.send() 
 
})



advBtn.addEventListener("click", (e) => {
    e.preventDefault();

    advSection.classList.toggle("hidden")

})



advSearchButton.addEventListener("click", (e) => {
    e.preventDefault();

    results.classList.add("mostrar");

    spawnSpinner(results);

   let advSearchQry = [];

    for (i = 0; i < advInput.length; i++) {

        advSearchQry.push(cleanAndPrep(advInput[i].value))
    }

    


    xhr.open("GET", `../Libros/BusquedaAnidada?titulo=${advSearchQry[0]}&autor=${advSearchQry[2]}&genero=${advSearchQry[1]}&editorial=${advSearchQry[3]} `)


    xhr.addEventListener("readystatechange", () => {


        if (xhr.status === 200 && xhr.readyState === 4) {

            results.innerHTML = ""

            var resultadosfinales = JSON.parse(xhr.response)




            //Checkea si no encontró nada y responde.
            if (resultadosfinales === "Lo sentimos. No hemos encontrado resultados.") {
                let bookDisplay = document.createElement("div");
                bookDisplay.classList = `resultadoBusqueda`
                bookDisplay.innerHTML = "Tu busqueda está en otro castillo."
                results.appendChild(bookDisplay);
            }


            //Devuleve resultados.
            else {
                for (var i = 0; i < resultadosfinales.length; i++) {
                    for (var u = 0; u < resultadosfinales[i].length; u++) {


                        let bookDisplay = document.createElement("div");
                        let bookDisplayTxt = document.createElement("p");

                        bookDisplay.classList = `resultadoBusqueda`
                        bookDisplayTxt.classList = `resultadoTexto`

                        bookDisplayTxt.innerHTML = `Titulo: ${resultadosfinales[i][u].titulo}.   Autor: ${resultadosfinales[i][u].nombre}.   
                         ISBN: ${resultadosfinales[i][u].ISBN}. Editorial: ${resultadosfinales[i][u].Editorial}. Genero: ${resultadosfinales[i][u].Genero}
                           <a  href="/Editar/EditarLibro/${resultadosfinales[i][u].Id}"><i class="fas fa-pencil-alt resIcon"> </i></a>  
                            <a  href="/Eliminar/EliminarLibro/${resultadosfinales[i][u].Id}"><i class="fas killIcon fa-trash resIcon"> </i></a>                                                                                                          `



                        bookDisplay.appendChild(bookDisplayTxt);


                        results.appendChild(bookDisplay);


                    }
                }
                selfDestruct();
            }






        }
    })

    xhr.send()

})



let selfDestruct = () => {

    let killIconArray = document.querySelectorAll(".killIcon");

    for (i = 0; i < killIconArray.length; i++) {

        killIconArray[i].addEventListener("click", (e) => {
            e.preventDefault();

         

            let a = document.createElement("div")

            a.innerText = "Seguro desea eliminar este libro?"
            
            let destroyButton = document.createElement("button")  
            destroyButton.value = "destroy"
            destroyButton.innerHTML = "Si"
           
            let escapeButton = document.createElement("button")
            escapeButton.value = "escape"
            escapeButton.innerHTML = "No"
            
            

            let addListener = (f) => {
                console.log(f)

                f.addEventListener("click", (e) => {
                   
                    if (e.target.value === "destroy") {


                        window.open(e.target.parentElement.parentElement.children[1].pathname)


                    }
                    else if
                    (e.target.value === "escape") {

                        e.target.parentElement.parentElement.removeChild(a)
                    
                    }
                    
                }
            )
            }

            console.log(e.target.parentElement.parentElement)
            

            addListener(destroyButton);
            addListener(escapeButton)


            a.appendChild(destroyButton)
            a.appendChild(escapeButton)


            a.className = "confirm"

            e.target.parentElement.parentElement.appendChild(a)

           
            

        })


    }


}


        let title = document.querySelector("h1");
        let body = document.querySelector("body");







