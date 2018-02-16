/// <reference path='../../../typings/index.d.ts' />
import initSetFunctions from './SetFunctions'
const resourceStartHandler = API.onResourceStart.connect(registerEvents)

async function registerEvents() {
  resourceStartHandler.disconnect()
  initSetFunctions()
};
