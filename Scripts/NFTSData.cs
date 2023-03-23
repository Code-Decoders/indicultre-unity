using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class NFTData
{
    public int id;
    public string owner;
    public string min_bid;
    public string highest_bidder;
    public string end_timestamp;

    public NFTData(int id, string owner, string min_bid, string highest_bidder, string end_timestamp) {
        this.id = id;
        this.owner = owner;
        this.min_bid = min_bid;
        this.highest_bidder = highest_bidder;
        this.end_timestamp = end_timestamp;
    }

    public string toString()
    {
        return "ID:" + this.id + " End TimeStamp:" + this.end_timestamp;
    }
}

[System.Serializable]
public class NFTS
{
    public IDictionary<int, NFT> nfts = new Dictionary<int, NFT>();

    public NFTS()
    {
        this.nfts.Add(1, new NFT(
            new NFTLanguage("Rajasthani Artifact", "Handcrafted mud Rajasthani Idol Showpiece"),
            new NFTLanguage("રાજસ્થાની આર્ટિફેક્ટ", "હસ્તકલા માટી રાજસ્થાની મૂર્તિ શોપીસ"),
            "Press 'B' to Bid"));
        this.nfts.Add(2, new NFT(
            new NFTLanguage("AnnaLakshmi", "Anna Lakshmi is a Hindu goddess who is worshipped for wealth and prosperity. She is believed to bring abundance and good fortune to her devotees. She is depicted with gold ornaments, adorned with flowers and holding a pot of gold in her hand. She is considered to be a form of Lakshmi, the Hindu goddess of wealth."),
            new NFTLanguage("અન્નલક્ષ્મી", " લક્ષ્મી એક હિન્દુ દેવી છે જે સંપત્તિ અને સમૃદ્ધિ માટે પૂજાય છે. એવું માનવામાં આવે છે કે તેણી તેના ભક્તો માટે વિપુલતા અને સારા નસીબ લાવે છે. તેણીને સોનાના આભૂષણો સાથે દર્શાવવામાં આવી છે, જે ફૂલોથી શણગારેલી છે અને તેના હાથમાં સોનાનો વાસણ ધરાવે છે. તેણીને લક્ષ્મીનું સ્વરૂપ માનવામાં આવે છે, જે હિંદુ સંપત્તિની દેવી છે."),
            "Press 'B' to Bid"));
        this.nfts.Add(3, new NFT(
            new NFTLanguage("Shankh", "Shankh, also known as a conch shell, is a sacred symbol in Hinduism. It is considered an auspicious instrument used in Hindu ceremonies and prayers, symbolizing the power of Lord Vishnu and the creation of the universe. In Hindu mythology, Lord Vishnu's conch shell is called Panchajanya, which symbolizes his strength and control over the world."),
            new NFTLanguage("શંખ", "શંખ, જેને શંખ તરીકે પણ ઓળખવામાં આવે છે, તે હિન્દુ ધર્મમાં એક પવિત્ર પ્રતીક છે. તે ભગવાન વિષ્ણુની શક્તિ અને બ્રહ્માંડની રચનાનું પ્રતીક, હિન્દુ સમારંભો અને પ્રાર્થનાઓમાં વપરાતું એક શુભ સાધન માનવામાં આવે છે. હિન્દુ પૌરાણિક કથાઓમાં, ભગવાન વિષ્ણુના શંખને પંચજન્ય કહેવામાં આવે છે, જે વિશ્વ પર તેમની શક્તિ અને નિયંત્રણનું પ્રતીક છે."),
             
             
            "Press 'B' to Bid"));
        this.nfts.Add(4, new NFT(
            new NFTLanguage("Map Of Gujarat, India", "Gujarat has a rich heritage, with a diverse culture and history dating back thousands of years. The state is known for its ancient Indus Valley Civilization sites, such as the city of Lothal. Gujarat is also home to many important Hindu and Jain temples, such as the Somnath Temple and the Palitana Temples."),
            new NFTLanguage("ગુજરાત, ભારત નકશો", "ગુજરાત પાસે સમૃદ્ધ વારસો છે, જેમાં વૈવિધ્યસભર સંસ્કૃતિ અને ઇતિહાસ હજારો વર્ષ જૂનો છે. રાજ્ય તેના પ્રાચીન સિંધુ ખીણની સંસ્કૃતિના સ્થળો માટે જાણીતું છે, જેમ કે લોથલ શહેર. ગુજરાતમાં સોમનાથ મંદિર અને પાલિતાણા મંદિરો જેવા ઘણા મહત્વપૂર્ણ હિન્દુ અને જૈન મંદિરો પણ છે."),
             
             
            "Press 'B' to Bid"));
        this.nfts.Add(5, new NFT(
            new NFTLanguage("Handcrafted Wooden Doll", "It is a wooden doll and the texture is given of a traditional indian women. It can open it up and when its open there ia another doll inside in smaller scale showed up. It have 5 difftrent scale dolls inside of it. So, whatever wants to put it in put it inside it and that is the essential character of this wooden doll. It was a very good experience to using this software. Created in RealityCapture by Capturing Reality from 298 images in 03h:13m:44s."),
            new NFTLanguage("હસ્તકલા લાકડાની ઢીંગલી", "તે લાકડાની ઢીંગલી છે અને તેનું ટેક્સચર પરંપરાગત ભારતીય મહિલાઓનું છે. તે તેને ખોલી શકે છે અને જ્યારે તે ખુલે છે ત્યારે તેની અંદર એક નાની ઢીંગલી દેખાય છે. તેની અંદર 5 અલગ-અલગ સ્કેલ ડોલ્સ છે. તેથી, જે પણ તેને મૂકવું હોય તે તેની અંદર મૂકો અને તે આ લાકડાની ઢીંગલીનું આવશ્યક પાત્ર છે. આ સોફ્ટવેરનો ઉપયોગ કરવાનો ખૂબ જ સારો અનુભવ હતો. 03h:13m:44s માં 298 છબીઓમાંથી વાસ્તવિકતાને કેપ્ચર કરીને રિયાલિટીકેપ્ચરમાં બનાવવામાં આવ્યું."),
             
             
            "Press 'B' to Bid"));
        this.nfts.Add(6, new NFT(
            new NFTLanguage("Pithora Painting", "Pithora painting is a traditional art form from the central Indian state of Chhattisgarh. It is a ritualistic form of painting, typically created on the walls of homes and huts during weddings, births and other important events. Pithora paintings depict deities, animals and humans in vivid colors and bold forms, and are created using a mixture of cow dung and mud as the base, with natural pigments used for coloring."),
            new NFTLanguage("પિથોરા પેઇન્ટિંગ", "પિથોરા પેઇન્ટિંગ એ મધ્ય ભારતીય રાજ્ય છત્તીસગઢની પરંપરાગત કળા છે. તે પેઇન્ટિંગનું ધાર્મિક સ્વરૂપ છે, જે સામાન્ય રીતે લગ્ન, જન્મ અને અન્ય મહત્વપૂર્ણ ઘટનાઓ દરમિયાન ઘરો અને ઝૂંપડીઓની દિવાલો પર બનાવવામાં આવે છે. પિથોરાના ચિત્રોમાં દેવતાઓ, પ્રાણીઓ અને મનુષ્યોને આબેહૂબ રંગો અને ઘાટા સ્વરૂપોમાં દર્શાવવામાં આવ્યા છે, અને તે ગાયના છાણ અને માટીના મિશ્રણનો ઉપયોગ કરીને બનાવવામાં આવે છે, જેમાં રંગ માટે ઉપયોગમાં લેવાતા કુદરતી રંગદ્રવ્યો છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(7, new NFT(
            new NFTLanguage("Mata ni Pachedi", "Handmade Mata ni Pachedi is a vibrant and intricate traditional textile art form from Gujarat, India. Created by hand using a combination of stitching, embroidery, and patchwork, the tapestries depict Hindu deities and cultural motifs and serve as backdrops for religious ceremonies. Passed down through generations of women, it is a valued cultural heritage of Gujarat and an important source of livelihood for those who create them."),
            new NFTLanguage("માતા ની પછેડી", "હાથથી બનાવેલી માતા ની પછેડી એ ગુજરાત, ભારતની એક જીવંત અને જટિલ પરંપરાગત કાપડ કલા છે. સ્ટીચિંગ, એમ્બ્રોઇડરી અને પેચવર્કના મિશ્રણનો ઉપયોગ કરીને હાથ વડે બનાવેલ, ટેપેસ્ટ્રી હિન્દુ દેવતાઓ અને સાંસ્કૃતિક રૂપરેખાઓનું નિરૂપણ કરે છે અને ધાર્મિક સમારોહ માટે બેકડ્રોપ તરીકે સેવા આપે છે. મહિલાઓની પેઢીઓમાંથી પસાર થયેલ, તે ગુજરાતનો મૂલ્યવાન સાંસ્કૃતિક વારસો છે અને જેઓ તેને બનાવે છે તેમના માટે આજીવિકાનો એક મહત્વપૂર્ણ સ્ત્રોત છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(8, new NFT(
            new NFTLanguage("Warli Painting", "Warli Painting is a traditional form of Indian folk art from the Warli tribe in Maharashtra. It features simple, geometric shapes and stick figures depicting daily life, nature and rituals. Done on mud walls or paper, Warli paintings use a minimalist style and earthy color palette to create a harmonious depiction of rural life. It is a significant cultural representation of the Warli tribe and a cherished art form in India."),
            new NFTLanguage("વારલી પેઈન્ટીંગ", "વારલી પેઈન્ટીંગ એ મહારાષ્ટ્રની વારલી જનજાતિની ભારતીય લોક કલાનું પરંપરાગત સ્વરૂપ છે. તેમાં રોજિંદા જીવન, પ્રકૃતિ અને ધાર્મિક વિધિઓ દર્શાવતી સરળ, ભૌમિતિક આકારો અને લાકડીની આકૃતિઓ છે. માટીની દિવાલો અથવા કાગળ પર કરવામાં આવેલ, વારલી ચિત્રો ગ્રામીણ જીવનનું સુમેળભર્યું નિરૂપણ બનાવવા માટે ઓછામાં ઓછી શૈલી અને માટીના રંગની પેલેટનો ઉપયોગ કરે છે. તે વારલી જનજાતિનું નોંધપાત્ર સાંસ્કૃતિક પ્રતિનિધિત્વ છે અને ભારતમાં એક પ્રિય કલા સ્વરૂપ છે."),
             
             
            "Press 'B' to Bid"));
        this.nfts.Add(9, new NFT(
            new NFTLanguage("Banajara Work", "Ethnic Banjara is a type of Indian vintage textile art originating from the Banjara nomadic tribe in Gujarat and Rajasthan. Known for its intricate and brightly colored hand embroidery, the art features traditional motifs and patterns inspired by the Banjara's nomadic lifestyle and cultural beliefs. The art form is often used in creating clothing, bags, and other decorative textiles and is an important part of the cultural heritage of the Banjara tribe and Gujarat."),
            new NFTLanguage("બંજારા વર્ક", "એથનિક બંજારા એ ભારતીય વિન્ટેજ કાપડ કલાનો એક પ્રકાર છે જે ગુજરાત અને રાજસ્થાનમાં બંજારા વિચરતી જાતિમાંથી ઉદ્દભવે છે. તેની જટિલ અને તેજસ્વી રંગીન હાથની ભરતકામ માટે જાણીતી, આ કલા બંજારાની વિચરતી જીવનશૈલી અને સાંસ્કૃતિક માન્યતાઓથી પ્રેરિત પરંપરાગત રૂપરેખાઓ અને પેટર્ન દર્શાવે છે. આ કલાનો ઉપયોગ કપડાં, બેગ અને અન્ય સુશોભન કાપડ બનાવવા માટે થાય છે અને તે બંજારા જાતિ અને ગુજરાતના સાંસ્કૃતિક વારસાનો એક મહત્વપૂર્ણ ભાગ છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(10, new NFT(
            new NFTLanguage("Kutch Embroidery", "Kutch Embroidery is a traditional form of needlework originating from the Kutch district of Gujarat, India. Known for its intricate designs, bold colors, and unique embellishments, Kutch embroidery is used to create a range of textiles including clothing, home decor, and accessories. The designs often feature geometric patterns, nature motifs, and vibrant mirrored embellishments, reflecting the rich cultural heritage of the region. Kutch embroidery is  an important source of livelihood for the women who create it."),
            new NFTLanguage("કચ્છ ભરતકામ", "કચ્છ ભરતકામ એ સોયકામનું પરંપરાગત સ્વરૂપ છે જે ભારતના ગુજરાતના કચ્છ જિલ્લામાંથી ઉદ્ભવે છે. તેની જટિલ ડિઝાઇન, ઘાટા રંગો અને અનન્ય શણગાર માટે જાણીતી, કચ્છ ભરતકામનો ઉપયોગ કપડાં, ઘરની સજાવટ અને એસેસરીઝ સહિત વિવિધ પ્રકારના કાપડ બનાવવા માટે થાય છે. આ ડિઝાઈનમાં મોટાભાગે ભૌમિતિક પેટર્ન, પ્રકૃતિની રચનાઓ અને વાઈબ્રન્ટ મિરર્ડ અલંકારો જોવા મળે છે, જે પ્રદેશના સમૃદ્ધ સાંસ્કૃતિક વારસાને પ્રતિબિંબિત કરે છે. કચ્છની ભરતકામ એ બનાવતી મહિલાઓ માટે આજીવિકાનું મહત્વનું સાધન છે."),
             
             
            "Press 'B' to Bid"));
        this.nfts.Add(11, new NFT(
            new NFTLanguage("Rogan Art Tree of Life", "Rogan Art, also known as 'Rogan Painting, ' is a traditional form of folk art from Kutch, India. It is a type of painting that uses a slow and methodical process of hand-painting thick, oil-based paint onto fabric. The 'Tree of Life' is a common theme in Rogan Art, depicting a lush and vibrant tree filled with animals, birds, and other elements of nature. The vibrant colors, intricate details, and organic shapes make Rogan Art a truly unique and captivating form of art."),
            new NFTLanguage("રોગન આર્ટ ટ્રી ઓફ લાઈફ", "રોગન આર્ટ, જેને 'રોગન પેઈન્ટિંગ' તરીકે પણ ઓળખવામાં આવે છે, તે કચ્છ, ભારતની લોક કલાનું પરંપરાગત સ્વરૂપ છે. તે પેઇન્ટિંગનો એક પ્રકાર છે જે ફેબ્રિક પર જાડા, તેલ આધારિત પેઇન્ટ હાથથી પેઇન્ટિંગ કરવાની ધીમી અને પદ્ધતિસરની પ્રક્રિયાનો ઉપયોગ કરે છે. રોગન આર્ટમાં 'ટ્રી ઓફ લાઈફ' એ એક સામાન્ય થીમ છે, જે પ્રાણીઓ, પક્ષીઓ અને પ્રકૃતિના અન્ય તત્વોથી ભરેલા લીલાછમ અને ગતિશીલ વૃક્ષને દર્શાવે છે. વાઇબ્રન્ટ રંગો, જટિલ વિગતો અને કાર્બનિક આકારો રોગાન આર્ટને ખરેખર અનન્ય અને મનમોહક કલા બનાવે છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(12, new NFT(
            new NFTLanguage("Village Life of Bhil", "Bhil Pithora Painting is a traditional form of Indian folk art from the Bhil tribe of central India. It depicts rural village life, with themes ranging from daily activities to religious rituals and beliefs. The paintings are characterized by vibrant colors, bold lines, and intricate details, often featuring human and animal figures in action. Painted on mud walls of homes or on cloth, Bhil Pithora Painting is an important cultural representation of the Bhil tribe and their way of life."),
            new NFTLanguage("ભીલનું ગ્રામ્ય જીવન", "ભીલ પિથોરા પેઈન્ટીંગ એ મધ્ય ભારતની ભીલ જાતિની ભારતીય લોક કલાનું પરંપરાગત સ્વરૂપ છે. તે ગ્રામીણ ગ્રામીણ જીવનને દર્શાવે છે, જેમાં દૈનિક પ્રવૃત્તિઓથી લઈને ધાર્મિક વિધિઓ અને માન્યતાઓ સુધીની થીમ્સ છે. ચિત્રો ગતિશીલ રંગો, બોલ્ડ રેખાઓ અને જટિલ વિગતો દ્વારા વર્ગીકૃત થયેલ છે, જેમાં ઘણીવાર માનવ અને પ્રાણીની આકૃતિઓ ક્રિયામાં હોય છે. ઘરોની માટીની દિવાલો પર અથવા કાપડ પર દોરવામાં આવેલ ભીલ પિથોરા પેઈન્ટીંગ એ ભીલ જાતિ અને તેમની જીવનશૈલીનું મહત્વનું સાંસ્કૃતિક પ્રતિનિધિત્વ છે."),
            
            "Press 'B' to Bid"));
        this.nfts.Add(13, new NFT(
            new NFTLanguage("The Dandia Celebration", "The Dandia Celebration is an acrylic on canvas painting by artist Ranjit Sarkars. It captures the vibrant energy and celebration of the Dandia, a traditional dance and festival in India. With its bold brushstrokes, bright colors, and dynamic movement, the painting showcases the joy and spirit of the event. This artwork is a beautiful representation of India's rich cultural heritage and the talent of the artist, Ranjit Sarkars, in bringing cultural elements to life through his art."),
            new NFTLanguage("દાંડિયા સેલિબ્રેશન", "દાંડિયા સેલિબ્રેશન કલાકાર રણજીત સરકાર દ્વારા કેનવાસ પેઇન્ટિંગ પર એક્રેલિક છે. તે ભારતમાં પરંપરાગત નૃત્ય અને તહેવાર દાંડિયાની જીવંત ઊર્જા અને ઉજવણીને કેપ્ચર કરે છે. તેના બોલ્ડ બ્રશસ્ટ્રોક્સ, તેજસ્વી રંગો અને ગતિશીલ ચળવળ સાથે, પેઇન્ટિંગ ઇવેન્ટનો આનંદ અને ભાવના દર્શાવે છે. આ આર્ટવર્ક ભારતના સમૃદ્ધ સાંસ્કૃતિક વારસા અને કલાકાર રણજિત સરકારની પ્રતિભાનું સુંદર પ્રતિનિધિત્વ છે, જે તેમની કલા દ્વારા સાંસ્કૃતિક તત્વોને જીવંત બનાવે છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(14, new NFT(
            new NFTLanguage("The Divine Nandi", "Nandi is a Hindu religious symbol and a sacred bull in Hinduism. It is considered the mount (vahana) of Lord Shiva and is often depicted as a bull or bull calf with a serene expression. Nandi is revered as an embodiment of purity, strength, and fertility and is worshipped by millions of Hindus around the world. Nandi is considered the gatekeeper of Lord Shiva's abode and is believed to grant blessings to devotees who visit and offer prayers to him. Nandi is also associated with several Hindu myths and legends."),
            new NFTLanguage("દિવ્ય નંદી", "નંદી એક હિંદુ ધાર્મિક પ્રતીક અને હિંદુ ધર્મમાં પવિત્ર બળદ છે. તેને ભગવાન શિવનો પર્વત (વાહન) માનવામાં આવે છે અને તેને ઘણી વખત શાંત અભિવ્યક્તિ સાથે બળદ અથવા બળદના વાછરડા તરીકે દર્શાવવામાં આવે છે. નંદીને શુદ્ધતા, શક્તિ અને ફળદ્રુપતાના મૂર્ત સ્વરૂપ તરીકે આદરવામાં આવે છે અને વિશ્વભરના લાખો હિન્દુઓ દ્વારા તેની પૂજા કરવામાં આવે છે. નંદીને ભગવાન શિવના નિવાસસ્થાનનો દ્વારપાળ માનવામાં આવે છે અને એવું માનવામાં આવે છે કે જેઓ તેમની મુલાકાત લે છે અને તેમની પ્રાર્થના કરે છે તેમને આશીર્વાદ આપે છે. નંદી અનેક હિંદુ દંતકથાઓ અને દંતકથાઓ સાથે પણ સંકળાયેલા છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(15, new NFT(
            new NFTLanguage("Krishna and radha", "Krishna and Radha symbolize divine love and devotion in Hindu mythology. Krishna, the god of compassion and love, is often depicted with his consort Radha, who represents the soul's devotion to God. Their story is a timeless tale of love and devotion, where Radha's love for Krishna is seen as the epitome of true devotion and selfless love. The love between Krishna and Radha is revered as a symbol of divine love and inspires many devotees to seek a similar connection with the divine."),  
            new NFTLanguage("કૃષ્ણ અને રાધા", "કૃષ્ણ અને રાધા હિન્દુ પૌરાણિક કથાઓમાં દૈવી પ્રેમ અને ભક્તિનું પ્રતીક છે. કરુણા અને પ્રેમના દેવ કૃષ્ણને ઘણીવાર તેમની પત્ની રાધા સાથે દર્શાવવામાં આવે છે, જે ભગવાન પ્રત્યેની આત્માની ભક્તિનું પ્રતિનિધિત્વ કરે છે. તેમની વાર્તા પ્રેમ અને ભક્તિની કાલાતીત વાર્તા છે, જ્યાં કૃષ્ણ માટે રાધાના પ્રેમને સાચી ભક્તિ અને નિઃસ્વાર્થ પ્રેમના પ્રતીક તરીકે જોવામાં આવે છે. કૃષ્ણ અને રાધા વચ્ચેનો પ્રેમ દૈવી પ્રેમના પ્રતીક તરીકે આદરણીય છે અને ઘણા ભક્તોને દૈવી સાથે સમાન જોડાણ મેળવવા માટે પ્રેરણા આપે છે."),  
            
            "Press 'B' to Bid"));
        this.nfts.Add(16, new NFT(
            new NFTLanguage("Ganesha", "Ganesha is a Hindu god, widely revered as the remover of obstacles and the patron of arts and sciences. He is the son of the god Shiva and the goddess Parvati, and is depicted as a plump, elephant-headed man, holding a broken tusk that he uses as a writing implement and a sweet treat called modaka in his hand. Ganesha is widely worshipped at the start of new ventures, religious ceremonies, and spiritual journeys. Ganesha is considered one of the most popular and widely recognized gods."),
            new NFTLanguage("ગણેશ", "ગણેશ એક હિંદુ દેવ છે, જે અવરોધોને દૂર કરનાર અને કળા અને વિજ્ઞાનના આશ્રયદાતા તરીકે વ્યાપકપણે આદરણીય છે. તે ભગવાન શિવ અને દેવી પાર્વતીનો પુત્ર છે, અને તેને એક ભરાવદાર, હાથીના માથાવાળા માણસ તરીકે દર્શાવવામાં આવ્યો છે, તે તૂટેલી દાંડી ધરાવે છે જેનો તે લખાણના સાધન તરીકે ઉપયોગ કરે છે અને તેના હાથમાં મોદકા તરીકે ઓળખાય છે. નવા સાહસો, ધાર્મિક વિધિઓ અને આધ્યાત્મિક યાત્રાઓની શરૂઆતમાં ગણેશની પૂજા વ્યાપકપણે કરવામાં આવે છે. ગણેશને સૌથી લોકપ્રિય અને વ્યાપકપણે માન્યતા પ્રાપ્ત દેવતાઓમાંના એક ગણવામાં આવે છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(17, new NFT(
            new NFTLanguage("Shiva:The Destroyer", "Shiva is a Hindu god who represents destruction, creation and renewal. He is often depicted as the cosmic dancer and is considered to be the third god in the Hindu trinity, along with Brahma and Vishnu. Shiva is revered for his power, wisdom, and is seen as a protector of the universe. He is also known for his compassion and is worshipped as a symbol of love and fertility. The festival of Maha Shivaratri is dedicated to Shiva and is celebrated with great devotion and enthusiasm by his followers all over the world."),
            new NFTLanguage("શિવ: ધ ડિસ્ટ્રોયર", "શિવ એક હિન્દુ દેવ છે જે વિનાશ, સર્જન અને નવીકરણનું પ્રતિનિધિત્વ કરે છે. તેને ઘણીવાર કોસ્મિક નૃત્યાંગના તરીકે દર્શાવવામાં આવે છે અને બ્રહ્મા અને વિષ્ણુની સાથે હિંદુ ટ્રિનિટીમાં ત્રીજા દેવ તરીકે ગણવામાં આવે છે. શિવ તેમની શક્તિ, શાણપણ માટે આદરણીય છે અને બ્રહ્માંડના રક્ષક તરીકે જોવામાં આવે છે. તેઓ તેમની કરુણા માટે પણ જાણીતા છે અને પ્રેમ અને ફળદ્રુપતાના પ્રતીક તરીકે તેમની પૂજા કરવામાં આવે છે. મહા શિવરાત્રીનો તહેવાર શિવને સમર્પિત છે અને સમગ્ર વિશ્વમાં તેમના અનુયાયીઓ દ્વારા ખૂબ જ ભક્તિ અને ઉત્સાહ સાથે ઉજવવામાં આવે છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(18, new NFT(
            new NFTLanguage("Sitar", "The sitar is a plucked string instrument that is widely used in Indian classical music. It has a distinctive sound and is known for its long neck and numerous strings. The sitar is made from a gourd resonating chamber, a wooden body, and a wooden neck with metal frets. It is played with a plectrum called a mizrab, and the musician can produce a wide range of sounds by adjusting the pressure and placement of their fingers on the strings. The sitar has a complex and rich history."),
            new NFTLanguage("સિતાર", "સિતાર એ એક ખેંચાયેલ તારનું વાદ્ય છે જેનો ભારતીય શાસ્ત્રીય સંગીતમાં વ્યાપકપણે ઉપયોગ થાય છે. તેનો વિશિષ્ટ અવાજ છે અને તે તેની લાંબી ગરદન અને અસંખ્ય તાર માટે જાણીતો છે. સિતાર ગોળ ગૂંજતી ચેમ્બર, લાકડાના શરીર અને ધાતુના ફ્રેટ્સ સાથે લાકડાના ગળામાંથી બનાવવામાં આવે છે. તે મિઝરાબ નામના પ્લેક્ટ્રમ સાથે વગાડવામાં આવે છે અને સંગીતકાર તાર પર તેમની આંગળીઓના દબાણ અને સ્થાનને સમાયોજિત કરીને વિશાળ શ્રેણીના અવાજો ઉત્પન્ન કરી શકે છે. સિતારનો એક જટિલ અને સમૃદ્ધ ઇતિહાસ છે."),
             
            "Press 'B' to Bid"));
        this.nfts.Add(19, new NFT(
            new NFTLanguage("Stone Perfume Box", "A stone perfume box is a container, typically made of precious or semi-precious stones, that is used to store and transport small amounts of perfume. The boxes come in a variety of shapes and sizes, from small, ornate pendants to larger decorative boxes that can be displayed on a vanity or dresser. The stones used to make the boxes can include gems such as jade, agate, and amethyst, and the boxes are often embellished with intricate carvings and intricate designs."),
            new NFTLanguage("સ્ટોન પરફ્યુમ બોક્સ", "સ્ટોન પરફ્યુમ બોક્સ એ એક કન્ટેનર છે, જે સામાન્ય રીતે કિંમતી અથવા અર્ધ કિંમતી પથ્થરોથી બનેલું હોય છે, જેનો ઉપયોગ થોડી માત્રામાં અત્તર સંગ્રહિત કરવા અને પરિવહન કરવા માટે થાય છે. બૉક્સ વિવિધ આકારો અને કદમાં આવે છે, નાના, અલંકૃત પેન્ડન્ટથી લઈને મોટા સુશોભન બૉક્સ સુધી જે વેનિટી અથવા ડ્રેસર પર પ્રદર્શિત કરી શકાય છે. બોક્સ બનાવવા માટે વપરાતા પત્થરોમાં જેડ, એગેટ અને એમિથિસ્ટ જેવા રત્નોનો સમાવેશ થઈ શકે છે અને બોક્સ ઘણીવાર જટિલ કોતરણી અને જટિલ ડિઝાઇનથી શણગારવામાં આવે છે."),
             
             
            "Press 'B' to Bid"));
        this.nfts.Add(20, new NFT(
            new NFTLanguage("Tabla", "Tabla is a percussion instrument from India that consists of two drums, the smaller bayan (bass) and the larger dayan (treble). The drums are played with the hands, and produce a wide range of sounds, from low bass notes to high-pitched, rhythmic sounds. Tabla is widely used in classical Indian music, as well as in popular genres like Bollywood film music and Qawwali devotional music. The instrument is known for its versatility and dynamic sound. Tabla is also widely used as a solo instrument."),
            new NFTLanguage("તબલા", "તબલા એ ભારતનું એક પર્ક્યુસન વાદ્ય છે જેમાં બે ડ્રમનો સમાવેશ થાય છે, નાના બાયન (બાસ) અને મોટા દયાન (ટ્રેબલ). ડ્રમ્સ હાથ વડે વગાડવામાં આવે છે, અને નીચા બાસ નોટ્સથી લઈને ઉચ્ચ-પીચ, લયબદ્ધ અવાજો સુધીના અવાજોની વિશાળ શ્રેણી ઉત્પન્ન કરે છે. શાસ્ત્રીય ભારતીય સંગીત તેમજ બોલીવુડ ફિલ્મ સંગીત અને કવ્વાલી ભક્તિ સંગીત જેવી લોકપ્રિય શૈલીઓમાં તબલાનો વ્યાપક ઉપયોગ થાય છે. આ સાધન તેની વૈવિધ્યતા અને ગતિશીલ અવાજ માટે જાણીતું છે. તબલાનો એકલ વાદ્ય તરીકે પણ વ્યાપકપણે ઉપયોગ થાય છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(21, new NFT(
            new NFTLanguage("Indian Tradtional Band", "Etikoppaka toys are traditional wooden toys from South India, known for their intricate design and vibrant colors. The toys are made using the 'Band Lacing' technique, where thin strips of wood are interwoven to create the final form. These handmade toys are a unique and colorful representation of South Indian heritage and culture."),
            new NFTLanguage("ભારતીય પરંપરાગત બેન્ડ", "એટીકોપ્પાકા રમકડાં દક્ષિણ ભારતના પરંપરાગત લાકડાના રમકડાં છે, જે તેમની જટિલ ડિઝાઇન અને વાઇબ્રન્ટ રંગો માટે જાણીતા છે. રમકડાં 'બેન્ડ લેસિંગ' તકનીકનો ઉપયોગ કરીને બનાવવામાં આવે છે, જ્યાં અંતિમ સ્વરૂપ બનાવવા માટે લાકડાની પાતળી પટ્ટીઓ ગૂંથવામાં આવે છે. આ હાથથી બનાવેલા રમકડાં દક્ષિણ ભારતીય વારસો અને સંસ્કૃતિનું અનોખું અને રંગીન પ્રતિનિધિત્વ છે."),
            
            "Press 'B' to Bid"));
        this.nfts.Add(22, new NFT(
            new NFTLanguage("Dagger", "Indian daggers, also known as 'kirpan' or 'kukri, ' are traditional weapons that have symbolic and religious significance in India. They are typically made of metal and feature a curved blade, often decorated with intricate designs. In some cultures, they are worn as part of ceremonial dress or carried as a sign of authority."),
            new NFTLanguage("કટારી", "ભારતીય ખંજર, જેને 'કિર્પાન' અથવા 'કુકરી' તરીકે પણ ઓળખવામાં આવે છે, તે પરંપરાગત શસ્ત્રો છે જે ભારતમાં સાંકેતિક અને ધાર્મિક મહત્વ ધરાવે છે. તેઓ સામાન્ય રીતે ધાતુના બનેલા હોય છે અને તેમાં વક્ર બ્લેડ હોય છે, જે ઘણીવાર જટિલ ડિઝાઇનથી શણગારવામાં આવે છે. કેટલીક સંસ્કૃતિઓમાં, તેઓ ઔપચારિક ડ્રેસના ભાગ રૂપે પહેરવામાં આવે છે અથવા સત્તાના સંકેત તરીકે વહન કરવામાં આવે છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(23, new NFT(
            new NFTLanguage("Mirabai", "Mirabai was a Hindu mystic poet and devotee of Lord Krishna, who lived in Rajasthan, India during the 16th century. Her devotional bhajans and poems, filled with love and devotion for Krishna, are considered some of the greatest works of devotional poetry in the Hindi language. Despite facing opposition from her family for her devotion."),
            new NFTLanguage("મીરાબાઈ", "મીરાબાઈ એક હિંદુ રહસ્યવાદી કવિ અને ભગવાન કૃષ્ણના ભક્ત હતા, જેઓ 16મી સદી દરમિયાન ભારતના રાજસ્થાનમાં રહેતા હતા. કૃષ્ણ પ્રત્યેના પ્રેમ અને ભક્તિથી ભરપૂર તેણીના ભક્તિમય ભજનો અને કવિતાઓ, હિન્દી ભાષામાં ભક્તિ કવિતાની કેટલીક મહાન કૃતિઓ ગણાય છે. તેણીની નિષ્ઠા માટે તેના પરિવારના વિરોધનો સામનો કરવા છતાં."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(24, new NFT(
            new NFTLanguage("Mahavira", "Mahavira was the 24th and last Jain Tirthankara, a spiritual teacher and philosopher who lived in ancient India. He is known for his teachings on non-violence, truth, and self-realization. He advocated for ahimsa (non-harm) towards all living beings and played a significant role in the development of Jainism. Mahavira's principles and practices continue to be followed by Jains today."),
            new NFTLanguage("મહાવીર", "મહાવીર 24મા અને છેલ્લા જૈન તીર્થંકર હતા, જે આધ્યાત્મિક શિક્ષક અને ફિલસૂફ હતા જેઓ પ્રાચીન ભારતમાં રહેતા હતા. તેઓ અહિંસા, સત્ય અને આત્મ-અનુભૂતિ પરના તેમના ઉપદેશો માટે જાણીતા છે. તેમણે તમામ જીવો પ્રત્યે અહિંસાની હિમાયત કરી અને જૈન ધર્મના વિકાસમાં નોંધપાત્ર ભૂમિકા ભજવી. મહાવીરના સિદ્ધાંતો અને પ્રથાઓ આજે પણ જૈનો અનુસરે છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(25, new NFT(
            new NFTLanguage("Lord Narayana", "Lord Narayana, also known as Vishnu, is a major deity in Hinduism. He is revered as the sustainer and protector of the universe, and is often depicted holding a conch, a discus, and a mace. Narayana is considered to be an incarnation of the god Vishnu and is worshiped as the supreme deity in Vaishnavism. He is also referred to as Purushottama and is revered by millions of devotees across India and around the world."),
            new NFTLanguage("ભગવાન નારાયણ", "ભગવાન નારાયણ, જેને વિષ્ણુ તરીકે પણ ઓળખવામાં આવે છે, તે હિન્દુ ધર્મમાં મુખ્ય દેવતા છે. તે બ્રહ્માંડના નિર્વાહક અને સંરક્ષક તરીકે આદરણીય છે, અને ઘણી વખત શંખ, ડિસ્કસ અને ગદા સાથે દર્શાવવામાં આવે છે. નારાયણને ભગવાન વિષ્ણુનો અવતાર માનવામાં આવે છે અને વૈષ્ણવ ધર્મમાં સર્વોચ્ચ દેવતા તરીકે પૂજાય છે. તેમને પુરુષોત્તમા તરીકે પણ ઓળખવામાં આવે છે અને સમગ્ર ભારતમાં અને સમગ્ર વિશ્વમાં લાખો ભક્તો દ્વારા તેઓ આદરણીય છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(26, new NFT(
            new NFTLanguage("Golden Plated Palki", "A Golden Plated Palki is a type of ornate palanquin used to carry statues of Jain Tirthankaras during religious processions. It symbolizes dignity, grandeur and respect for the divine beings. The intricate designs and intricate metalwork on the palki add to its beauty and elevate the spiritual experience of those who use it."),
            new NFTLanguage("ગોલ્ડન પ્લેટેડ લાકડી", "ગોલ્ડન પ્લેટેડ પાલકી એ એક પ્રકારની અલંકૃત પાલખી છે જેનો ઉપયોગ ધાર્મિક સરઘસ દરમિયાન જૈન તીર્થંકરોની મૂર્તિઓ વહન કરવા માટે થાય છે. તે દૈવી માણસો માટે ગૌરવ, ભવ્યતા અને આદરનું પ્રતીક છે. પાલકી પરની જટિલ ડિઝાઇન અને જટિલ મેટલવર્ક તેની સુંદરતામાં વધારો કરે છે અને તેનો ઉપયોગ કરનારાઓના આધ્યાત્મિક અનુભવને વધારે છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(27, new NFT(
            new NFTLanguage("Gada", "The Hanuman Gada is a traditional Indian weapon that is considered sacred in Hinduism, particularly in the worship of Lord Hanuman. It is often depicted as a mace with a rounded head and a cylindrical shaft and is believed to represent strength, power, and protection. The Gada is often used as an emblem of religious authority and symbolizes the power of Lord Hanuman."),
            new NFTLanguage("ગદા", "હનુમાન ગડા એ પરંપરાગત ભારતીય શસ્ત્ર છે જે હિન્દુ ધર્મમાં પવિત્ર માનવામાં આવે છે, ખાસ કરીને ભગવાન હનુમાનની પૂજામાં. તેને ઘણીવાર ગોળાકાર માથા અને નળાકાર શાફ્ટ સાથે ગદા તરીકે દર્શાવવામાં આવે છે અને તે શક્તિ, શક્તિ અને રક્ષણનું પ્રતિનિધિત્વ કરે છે તેવું માનવામાં આવે છે. ગડાનો ઉપયોગ ઘણીવાર ધાર્મિક સત્તાના પ્રતીક તરીકે થાય છે અને તે ભગવાન હનુમાનની શક્તિનું પ્રતીક છે."),
            
             
            "Press 'B' to Bid"));
        this.nfts.Add(28, new NFT(
            new NFTLanguage("Metal Elephant Toy", "The metal elephant toy is a traditional cultural artifact originating from the Indian state of Gujarat. Made from metal, these toys are typically handcrafted and come in a variety of sizes, ranging from small keychains to large decorative pieces. The intricate details on these toys make them unique and visually appealing, and they are often used as decorations in homes or as souvenirs for tourists. The elephant is a revered animal in Hindu culture."),
            new NFTLanguage("મેટલ એલિફન્ટ ટોય", "મેટલ એલિફન્ટ ટોય એ ભારતના ગુજરાત રાજ્યમાંથી ઉદ્દભવતી પરંપરાગત સાંસ્કૃતિક કલાકૃતિ છે. ધાતુમાંથી બનેલા, આ રમકડાં સામાન્ય રીતે હાથથી બનાવેલા હોય છે અને નાના કીચેનથી લઈને મોટા સુશોભન ટુકડાઓ સુધીના વિવિધ કદમાં આવે છે. આ રમકડાં પરની જટિલ વિગતો તેમને અનન્ય અને દૃષ્ટિની આકર્ષક બનાવે છે, અને તેનો ઉપયોગ ઘણીવાર ઘરોમાં સજાવટ તરીકે અથવા પ્રવાસીઓ માટે સંભારણું તરીકે થાય છે. હિંદુ સંસ્કૃતિમાં હાથી એક આદરણીય પ્રાણી છે."),
            "Press 'B' to Bid"));

    }
}

[System.Serializable]
public class NFT
{
    public NFTLanguage english;
    public NFTLanguage gujarati;
    public string bidText;

    public NFT(NFTLanguage _english, NFTLanguage _gujarati, string _bid)
    {
        english = _english;
        gujarati = _gujarati;
        bidText = _bid;
    }

    public string ToString => "English: " + english.ToString() + "\nGujarati: " + gujarati.ToString();
}

[System.Serializable]
public class NFTLanguage
{
    public string title;
    public string description;

    public NFTLanguage(string _title, string _desc)
    {
        title = _title;
        description = _desc;
    }

    public string ToString => " Title: " + title + "Description: " + description;


}