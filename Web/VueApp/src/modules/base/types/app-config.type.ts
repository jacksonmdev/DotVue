export type AppConfig = {
  loadCoreUiComponents: () => AppConfig
  loadComponents: (components: any[]) => AppConfig
  setLocal: (locale: string, useCustomLocal: boolean) => AppConfig
  setStore: () => AppConfig
}
