# Automs

Warning! Microsoft .NET Framework 4.0 or higher is required to run Automs, but for better performance, Microsoft .NET 4.5 or higher is required



How to use "Reset word experiment" correctly:

1. Do not attempt to use more then 6x2 DFAs for demonstration. Even 7x2 generation on AMD FX-6100 @ 3.6 GHz takes about half an hour. 
2. "Total segmentation" is how you divide multiplicity of ALL NxK DFAs; then "Calculate from" and "Calculate to" is which parts you will generate right now
3. To get fastest generation you should make number of parts to generate equal to your CPU's threads. By default Automs will put correct "Calc. to" to get this condition
4. Automs will use your CPU's threads by 100%, that will lead stuttering. Automs by default have low priority, but it may not work on your PC
5. "Shutdown PC" is currently unaviable because of Windows Defender
