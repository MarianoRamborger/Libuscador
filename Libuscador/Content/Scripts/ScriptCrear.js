
let addAnother = document.querySelectorAll(".addAnother")
let reqInputs = document.querySelectorAll(".reqInput");
let submitBtn = document.querySelector("#submitButton")
let errorPanel = document.querySelector("#errorPanel")






for (i = 0; i < addAnother.length; i++) {

   

    addAnother[i].addEventListener("click", (e) => {


        let newDiv = document.createElement("div")


        let copy;


        if (e.target.dataset.clave == "Autor") {

            target = document.getElementById("addAutores");
            copy = target.cloneNode(true);
        }

       else if (e.target.dataset.clave == "Genero") {

            target = document.getElementById("addGeneros");
            copy = target.cloneNode(true);
        }



        let killswitch = document.createElement("i");
        killswitch.className = "fas fa-book-dead killswitch"

        killswitch.addEventListener("click", (e) => {
            e.target.parentElement.parentElement.removeChild(newDiv)
        })

        newDiv.appendChild(copy);
        newDiv.appendChild(killswitch)
        e.target.parentElement.appendChild(newDiv)


    })



}


submitBtn.addEventListener("click", (e) => { 
    //Para checkear TODO junto.
    let ErrorList = [] 
    let emptyError = false
    let notALetterError = false
    let webError = false
    let titleError = false
    let repeatError = false;

    errorPanel.innerHTML = ""
 

    for (i = 0; i < reqInputs.length; i++)


        if (reqInputs[i].id == "ISBN") {
            let nanError = false

            let ISBNchk = reqInputs[i].value

            if (ISBNchk.length < 10 || (ISBNchk.length > 13)) {
                ErrorList.push("El ISBN debe contener entre 10 y 13 digitos <br/> ")
            }

            for (u = 0; u < ISBNchk.length; u++) {



                if ((ISBNchk.charCodeAt(u) >= 48) && (ISBNchk.charCodeAt(u) <= 57)) {

                }
                else {
                    nanError = true
                }

            }

            if (nanError == true) {
                ErrorList.push("El ISBN solo puede contener numeros, y no puede contener espacios <br/>")
            }

        }

        else if ( (reqInputs[i].id == "Aut_Nombre" || (reqInputs[i].id == "Pais" || (reqInputs[i].id == "Nombre_editorial" ||
            (reqInputs[i].id == "Genero" || (reqInputs[i].id == "Descripcion"

            )))))) {


            let strCHK = reqInputs[i].value.trim()

            if (strCHK.length < 1) { emptyError = true }

            for (u = 0; u < strCHK.length; u++) {


                if ((strCHK.charCodeAt(u) == 32 || (strCHK.charCodeAt(u) == 46 ||
                    (strCHK.charCodeAt(u) >= 65 && (strCHK.charCodeAt(u) <= 90 ||
                    (strCHK.charCodeAt(u) >= 97 && (strCHK.charCodeAt(u) <= 122
                ))))))) {

                }
                else {
                    notALetterError = true;
                }
            }
            reqInputs[i].value = strCHK
          
        }

        else if (reqInputs[i].id == "Pagina_web") {


            let webCHK = reqInputs[i].value.trim()

            if (webCHK.length < 1) { emptyError = true }

            for (u = 0; u < webCHK.length; u++) {

                if ((webCHK.charCodeAt(u) >= 43 && (webCHK.charCodeAt(u) < 127 ))) {

                }
                else {
                    webError = true;
                }
            }

            reqInputs[i].value = webCHK
        } 

        else if (reqInputs[i].id == "Titulo") {


            let titleCHK = reqInputs[i].value.trim()

            if (titleCHK.length < 1) { emptyError = true }

            for (u = 0; u < titleCHK.length; u++) {

                if (
                    (titleCHK.charCodeAt(u) >= 32 && (titleCHK.charCodeAt(u) <= 90 ||
                    (titleCHK.charCodeAt(u) >= 97 && (titleCHK.charCodeAt(u) <= 122
                        )))))
                {

                }
                else {
                    titleError = true;
                }
            }

            reqInputs[i].value = titleCHK
        } 


    if (emptyError == true) { ErrorList.push("Por favor revise su solicitud. Todos los campos deben ser completados <br/> ") }
    if (notALetterError == true) { ErrorList.push("Por favor revise su solicitud. Uno o más campos tienen caracteres no permitidos.<br/>") }
    if (webError == true) { ErrorList.push("Por favor, revise la dirección web que ingresó.<br/>") }
    if (titleError == true) { ErrorList.push("El titulo que ingresó contiene caracteres inválidos. <br/>") }



   

    if (e.target.value == "Añadir libro!") {

        var autores = document.querySelectorAll(".autSelect")
        var generos = document.querySelectorAll(".genSelect")
        var editorial = document.querySelectorAll(".edSelect")
        
       



        selectValidation = (a) => {
            let selectedArray = []
            for (u = 0; u < a.length; u++) {
                let value = a[u].options[a[u].selectedIndex].value

                if (isNaN(value)) {
              
                    emptyError = true
                }

                if (selectedArray.find(a => a == value)) {
                    console.log(value)
                    repeatError = true;
                }
                else selectedArray.push(value)


            }

        }

        selectValidation(autores)
        selectValidation(generos)
        selectValidation(editorial)
       


        for (u = 0; u < generos.length; u++) {
            console.log(generos[u].childNodes)
        }




        if (repeatError == true) { ErrorList.push("Se detectaron campos repetidos. <br/>") }
    }

    
    if (ErrorList.length > 0) {
        let errorDisplay = document.createElement("div");
        errorDisplay.className = "errorDisplay"
        errorDisplay.innerHTML = ErrorList
        errorPanel.appendChild(errorDisplay)
        
        
    }

  



    






    else {

      
        document.querySelector("form").submit()
       
       
    }







})


