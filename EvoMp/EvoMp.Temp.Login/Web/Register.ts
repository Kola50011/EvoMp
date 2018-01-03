/// <reference path="../../typings/index.d.ts" />

interface RegisterForm extends HTMLFormControlsCollection {
  password: HTMLInputElement
  name: HTMLInputElement
  email: HTMLInputElement
}

function sendToClient(args: any) {
  try {
    resourceEval(
      `resource.CefEventHandlerSingleton.trigger('registerRequest', ${JSON.stringify(
        args
      )})`
    )
  } catch (error) {
    console.warn('resourceEval not supported!')
  }
}

function handleRegister(form: HTMLFormElement) {
  let inputs: RegisterForm = (form as any) as RegisterForm
  let password: string = inputs.password.value
  let name: string = inputs.name.value
  let email: string = inputs.email.value
  sendToClient({name: name, password: password, email: email})
}
