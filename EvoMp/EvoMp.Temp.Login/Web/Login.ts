/// <reference path="../../typings/index.d.ts" />

interface LoginForm extends HTMLFormControlsCollection {
  password: HTMLInputElement
  name: HTMLInputElement
}

function sendLoginRequest(args: any) {
  try {
    resourceEval(
      `resource.CefEventHandlerSingleton.trigger('loginRequest', ${JSON.stringify(
        args
      )})`
    )
  } catch (error) {
    console.warn('resourceEval not supported!')
  }
}

function handleLogin(form: HTMLFormElement) {
  let inputs: LoginForm = (form as any) as LoginForm
  let password: string = inputs.password.value
  let name: string = inputs.name.value

  sendLoginRequest({name: name, password: password})
}
