import{_ as A,o as m,c as u,a as n,b as y,F as l,r as g,d as i,w as f,e as x,P as v,A as B,f as t,g as a,h}from"./index.157985b7.js";const C={setup(){async function o(){try{await x.getAbilities()}catch(e){v.error(e.message,"[getAbilities] > AbilitiesPage")}}return m(()=>{o()}),{abilities:u(()=>B.abilities.sort((e,s)=>e.name.localeCompare(s.name)))}}},M={class:"abilities d-flex justify-content-center align-items-center gap-4"};function P(o,e,s,c,k,F){const r=t("AbilityCard"),_=t("AddButton"),b=t("AddAbilityForm"),p=t("AddModal");return a(),n(l,null,[y("div",M,[(a(!0),n(l,null,g(c.abilities,d=>(a(),h(r,{key:d.name,ability:d},null,8,["ability"]))),128))]),i(_,{buttonText:"Add Ability",modalId:"addAbilityModal"}),i(p,{modalId:"addAbilityModal"},{default:f(()=>[i(b)]),_:1})],64)}const I=A(C,[["render",P],["__scopeId","data-v-1d3d9c7d"]]);export{I as default};
