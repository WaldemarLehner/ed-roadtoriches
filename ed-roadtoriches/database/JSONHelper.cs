using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;




namespace ed_roadtoriches.database
{
    class JSONHelper
    {

       
        JSONHelper()
        {

        }

        public void ReadJSON(string file)
        {
            bool lastID = false,
                    lastSysName = false,
                    lastBodyName = false,
                    lastDTA = false,
                    lastOrbitalPeriod = false,
                    lastType = false,
                    lastTerraformable = false,
                    skitToID = false,
                    lastAny = false ;

            String sysname, bodyname;
            uint id, dta , orbitalperiod ;
            bool isTerraformable = false;
            byte type = 0; //1:ELW 2:AW 3:TF WW 4:WW (temp) 


            JsonTextReader streamReader = new JsonTextReader(new StreamReader(file));
            while (streamReader.Read())
            {
                if(streamReader.Value != null)


                {
                    if(skitToID){
                        if(String.Equals(streamReader.Value, "id"))
                        {
                            lastID = lastAny = true;
                            skitToID = false;
                        }
                    }
                    else if (lastAny)
                    {
                        if (lastID)
                        {
                            id = Convert.ToUInt32(streamReader.Value);
                            lastAny = lastID = false;

                        }
                        else if (lastBodyName)
                        {
                            bodyname = Convert.ToString(streamReader.Value);
                            lastAny = lastBodyName = false;
                        }
                        else if (lastType)
                        {
                            String s = Convert.ToString(streamReader.Value);
                            lastAny = lastType = false;
                            if(s.Equals("Earth-like world"))
                            {
                                type = 1;
                            }
                            else if(s.Equals("Ammonia world"))
                            {
                                type = 2;
                            }
                            else if(s.Equals("Water world"))
                            {
                                type = 4;
                            }
                            else
                            {
                                skitToID = true; // System is not a ELW/AW/WW > no need to check the rest
                            }
                        }
                        else if (lastDTA)
                        {
                            dta = Convert.ToUInt32(streamReader.Value);
                            lastAny = lastDTA = false;
                        }
                        else if (lastTerraformable)
                        {
                            lastTerraformable = lastAny = false;
                            String s = Convert.ToString(streamReader.Value);
                            if(s.Equals("Candidate for terraforming")&& type == 4)
                            {
                                type = 3;
                            }
                            else if(s.Equals("Not terraformable"))
                            {
                                skitToID = true;
                            }
                        }
                        else if (lastOrbitalPeriod)
                        {
                            lastOrbitalPeriod = lastAny = false;
                            orbitalperiod = Convert.ToUInt32(streamReader.Value);
                        }
                        else if (lastSysName)
                        {

                        }
                    }
                    else if (String.Equals(streamReader.Value, "id"))
                    {
                        lastID = lastAny = true;                   
                    }
                    else if (String.Equals(streamReader.Value, "name"))
                    {
                        lastBodyName = lastAny = true;
                    }
                    else if(String.Equals(streamReader.Value, "subtype"))
                    {
                        lastType = lastAny = true;
                    }
                    else if(String.Equals(streamReader.Value, "distanceToArrival"))
                    {
                        lastDTA = lastAny = true;
                    }
                    else if(String.Equals(streamReader.Value, "terraformingState"))
                    {
                        lastTerraformable = lastAny = true;
                    }
                    else if(String.Equals(streamReader.Value, "orbitalPeriod"))
                    {
                        lastOrbitalPeriod = lastAny = true;
                    }
                    else if(String.Equals(streamReader.Value, "systemName"))
                    {
                        lastSysName = lastAny = true;
                    }

                }
            }
        }
        


        
    }



   






}

