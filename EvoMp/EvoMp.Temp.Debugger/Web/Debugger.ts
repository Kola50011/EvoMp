function log(caller: string, str: string) {
  console.log(caller, JSON.parse(str))
}
function error(caller: string, str: string) {
  console.error(caller, JSON.parse(str))
}
function warn(caller: string, str: string) {
  console.warn(caller, JSON.parse(str))
}
